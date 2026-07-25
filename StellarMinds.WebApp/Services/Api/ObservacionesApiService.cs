namespace StellarMinds.WebApp.Services.Api;

public interface IObservacionesApiService
{
    Task<ApiResult<List<ApiPrestamo>>> ListarPrestamosVigentesAsync();
    Task<ApiResult<List<ApiObjetoCeleste>>> ListarObjetosCelestesAsync();
    Task<ApiResult<ApiEvaluacionObservacion>> EvaluarAsync(ApiEvaluarObservacion dto);
    Task<ApiResult> AltaAsync(ApiAltaObservacion dto);
}

public class ObservacionesApiService : IObservacionesApiService
{
    private readonly IApiClient _apiClient;

    public ObservacionesApiService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<ApiResult<List<ApiPrestamo>>> ListarPrestamosVigentesAsync()
    {
        return _apiClient.GetAsync<List<ApiPrestamo>>("api/observaciones/prestamos-vigentes");
    }

    public Task<ApiResult<List<ApiObjetoCeleste>>> ListarObjetosCelestesAsync()
    {
        return _apiClient.GetAsync<List<ApiObjetoCeleste>>("api/objetos-celestes");
    }

    public Task<ApiResult<ApiEvaluacionObservacion>> EvaluarAsync(ApiEvaluarObservacion dto)
    {
        return _apiClient.PostAsync<ApiEvaluarObservacion, ApiEvaluacionObservacion>("api/observaciones/evaluar", dto);
    }

    public Task<ApiResult> AltaAsync(ApiAltaObservacion dto)
    {
        return _apiClient.PostAsync("api/observaciones", dto);
    }
}
