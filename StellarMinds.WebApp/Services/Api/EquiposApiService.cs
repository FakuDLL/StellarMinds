namespace StellarMinds.WebApp.Services.Api;

public interface IEquiposApiService
{
    Task<ApiResult<List<ApiEquipo>>> ListarAsync(string? tipo = null);
    Task<ApiResult<ApiEquipo>> ObtenerAsync(int id);
    Task<ApiResult> AltaAsync(ApiEquipo dto);
    Task<ApiResult> ActualizarAsync(ApiEquipo dto);
    Task<ApiResult> BajaAsync(int id);
    Task<ApiResult<ApiDisponibilidadEquipo>> DisponibilidadAsync(string tipo, int id);
    Task<ApiResult<List<ApiUsuarioResumen>>> ListarSociosPorTelescopioAsync(int telescopioId);
}

public class EquiposApiService : IEquiposApiService
{
    private readonly IApiClient _apiClient;

    public EquiposApiService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<ApiResult<List<ApiEquipo>>> ListarAsync(string? tipo = null)
    {
        var url = string.IsNullOrWhiteSpace(tipo)
            ? "api/equipos"
            : $"api/equipos?tipo={Uri.EscapeDataString(tipo)}";

        return _apiClient.GetAsync<List<ApiEquipo>>(url);
    }

    public Task<ApiResult<ApiEquipo>> ObtenerAsync(int id)
    {
        return _apiClient.GetAsync<ApiEquipo>($"api/equipos/{id}");
    }

    public Task<ApiResult> AltaAsync(ApiEquipo dto)
    {
        return _apiClient.PostAsync("api/equipos", dto);
    }

    public Task<ApiResult> ActualizarAsync(ApiEquipo dto)
    {
        return _apiClient.PutAsync($"api/equipos/{dto.Id}", dto);
    }

    public Task<ApiResult> BajaAsync(int id)
    {
        return _apiClient.DeleteAsync($"api/equipos/{id}");
    }

    public Task<ApiResult<ApiDisponibilidadEquipo>> DisponibilidadAsync(string tipo, int id)
    {
        return _apiClient.GetAsync<ApiDisponibilidadEquipo>($"api/equipos/{Uri.EscapeDataString(tipo)}/{id}/disponibilidad");
    }

    public Task<ApiResult<List<ApiUsuarioResumen>>> ListarSociosPorTelescopioAsync(int telescopioId)
    {
        return _apiClient.GetAsync<List<ApiUsuarioResumen>>($"api/equipos/telescopios/{telescopioId}/socios");
    }
}
