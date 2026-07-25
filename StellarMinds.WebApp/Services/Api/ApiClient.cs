using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace StellarMinds.WebApp.Services.Api;

public interface IApiClient
{
    Task<ApiResult<T>> GetAsync<T>(string url);
    Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request);
    Task<ApiResult> PostAsync<TRequest>(string url, TRequest request);
    Task<ApiResult> PostAsync(string url);
    Task<ApiResult> PutAsync<TRequest>(string url, TRequest request);
    Task<ApiResult> DeleteAsync(string url);
}

public class ApiClient : IApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

    public ApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ApiResult<T>> GetAsync<T>(string url)
    {
        try
        {
            var response = await CreateClient().GetAsync(url);
            return await ReadResponse<T>(response);
        }
        catch
        {
            return ApiResult<T>.Error("No se pudo conectar con la API.");
        }
    }

    public async Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request)
    {
        try
        {
            var response = await CreateClient().PostAsJsonAsync(url, request);
            return await ReadResponse<TResponse>(response);
        }
        catch
        {
            return ApiResult<TResponse>.Error("No se pudo conectar con la API.");
        }
    }

    public async Task<ApiResult> PostAsync<TRequest>(string url, TRequest request)
    {
        try
        {
            var response = await CreateClient().PostAsJsonAsync(url, request);
            return await ReadResponse(response);
        }
        catch
        {
            return ApiResult.Error("No se pudo conectar con la API.");
        }
    }

    public async Task<ApiResult> PostAsync(string url)
    {
        try
        {
            var response = await CreateClient().PostAsync(url, null);
            return await ReadResponse(response);
        }
        catch
        {
            return ApiResult.Error("No se pudo conectar con la API.");
        }
    }

    public async Task<ApiResult> PutAsync<TRequest>(string url, TRequest request)
    {
        try
        {
            var response = await CreateClient().PutAsJsonAsync(url, request);
            return await ReadResponse(response);
        }
        catch
        {
            return ApiResult.Error("No se pudo conectar con la API.");
        }
    }

    public async Task<ApiResult> DeleteAsync(string url)
    {
        try
        {
            var response = await CreateClient().DeleteAsync(url);
            return await ReadResponse(response);
        }
        catch
        {
            return ApiResult.Error("No se pudo conectar con la API.");
        }
    }

    private HttpClient CreateClient()
    {
        var client = _httpClientFactory.CreateClient("ApiClient");
        var token = _httpContextAccessor.HttpContext?.Session.GetString("Token");
        if (!string.IsNullOrWhiteSpace(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return client;
    }

    private async Task<ApiResult<T>> ReadResponse<T>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            return ApiResult<T>.Error(await ReadError(response));

        var data = await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        return data == null ? ApiResult<T>.Error("La API devolvió una respuesta vacía.") : ApiResult<T>.Ok(data);
    }

    private async Task<ApiResult> ReadResponse(HttpResponseMessage response)
    {
        return response.IsSuccessStatusCode
            ? ApiResult.Ok()
            : ApiResult.Error(await ReadError(response));
    }

    private async Task<string> ReadError(HttpResponseMessage response)
    {
        var fallback = $"Error {(int)response.StatusCode} al consumir la API.";
        var content = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(content))
            return fallback;

        try
        {
            using var json = JsonDocument.Parse(content);
            if (json.RootElement.TryGetProperty("mensaje", out var mensaje))
                return mensaje.GetString() ?? fallback;
            if (json.RootElement.TryGetProperty("message", out var message))
                return message.GetString() ?? fallback;
        }
        catch
        {
        }

        return content;
    }
}
