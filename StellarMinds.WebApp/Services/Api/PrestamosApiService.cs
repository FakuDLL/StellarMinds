namespace StellarMinds.WebApp.Services.Api;

public interface IPrestamosApiService
{
    Task<ApiResult> AltaAsync(ApiAltaPrestamo dto);
    Task<ApiResult<List<ApiPrestamo>>> ListarPorSocioAsync(int socioId, string estado);
    Task<ApiResult<List<ApiPrestamoConAtraso>>> MisPrestamosAsync(int mes, int anio);
    Task<ApiResult> DevolverAsync(int prestamoId);
}

public class PrestamosApiService : IPrestamosApiService
{
    private readonly IApiClient _apiClient;

    public PrestamosApiService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<ApiResult> AltaAsync(ApiAltaPrestamo dto)
    {
        return _apiClient.PostAsync("api/Prestamos", dto);
    }

    public Task<ApiResult<List<ApiPrestamo>>> ListarPorSocioAsync(int socioId, string estado)
    {
        return _apiClient.GetAsync<List<ApiPrestamo>>($"api/Prestamos?socioId={socioId}&estado={Uri.EscapeDataString(estado)}");
    }

    public Task<ApiResult<List<ApiPrestamoConAtraso>>> MisPrestamosAsync(int mes, int anio)
    {
        return _apiClient.GetAsync<List<ApiPrestamoConAtraso>>($"api/prestamos/mis-prestamos?mes={mes}&anio={anio}");
    }

    public Task<ApiResult> DevolverAsync(int prestamoId)
    {
        return _apiClient.PostAsync($"api/Prestamos/{prestamoId}/devolver");
    }
}
