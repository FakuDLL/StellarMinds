namespace StellarMinds.WebApp.Services.Api;

public interface IUsuariosApiService
{
    Task<ApiResult> AltaSocioAsync(ApiAltaUsuario dto);
    Task<ApiResult<List<ApiUsuarioResumen>>> ListarSociosAsync();
}

public class UsuariosApiService : IUsuariosApiService
{
    private readonly IApiClient _apiClient;

    public UsuariosApiService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<ApiResult> AltaSocioAsync(ApiAltaUsuario dto)
    {
        dto.Rol = 3;
        return _apiClient.PostAsync("api/Usuarios", dto);
    }

    public Task<ApiResult<List<ApiUsuarioResumen>>> ListarSociosAsync()
    {
        return _apiClient.GetAsync<List<ApiUsuarioResumen>>("api/Usuarios?rol=Socio");
    }
}
