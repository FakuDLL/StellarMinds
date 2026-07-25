namespace StellarMinds.WebApp.Services.Api;

public interface IAuthApiService
{
    Task<ApiResult<ApiLoginResponse>> LoginAsync(string nombreUsuario, string password);
}

public class AuthApiService : IAuthApiService
{
    private readonly IApiClient _apiClient;

    public AuthApiService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<ApiResult<ApiLoginResponse>> LoginAsync(string nombreUsuario, string password)
    {
        return _apiClient.PostAsync<ApiLoginRequest, ApiLoginResponse>("api/Auth/login", new ApiLoginRequest
        {
            NombreUsuario = nombreUsuario,
            Password = password
        });
    }
}
