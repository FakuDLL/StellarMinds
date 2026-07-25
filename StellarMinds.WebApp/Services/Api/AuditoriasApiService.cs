namespace StellarMinds.WebApp.Services.Api;

public interface IAuditoriasApiService
{
    Task<ApiResult<List<ApiAuditoriaPrestamo>>> ListarAsync(int? coordinadorId = null);
    Task<ApiResult<ApiAuditoriaPrestamo>> ObtenerAsync(int id);
}

public class AuditoriasApiService : IAuditoriasApiService
{
    private readonly IApiClient _apiClient;

    public AuditoriasApiService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<ApiResult<List<ApiAuditoriaPrestamo>>> ListarAsync(int? coordinadorId = null)
    {
        var url = coordinadorId.HasValue
            ? $"api/auditorias?coordinadorId={coordinadorId.Value}"
            : "api/auditorias";

        return _apiClient.GetAsync<List<ApiAuditoriaPrestamo>>(url);
    }

    public Task<ApiResult<ApiAuditoriaPrestamo>> ObtenerAsync(int id)
    {
        return _apiClient.GetAsync<ApiAuditoriaPrestamo>($"api/auditorias/{id}");
    }
}
