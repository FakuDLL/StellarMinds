namespace StellarMinds.WebApp.Services.Api;

public interface IObjetosCelestesApiService
{
    Task<ApiResult<List<ApiRankingObjetoCeleste>>> RankingAsync();
}

public class ObjetosCelestesApiService : IObjetosCelestesApiService
{
    private readonly IApiClient _apiClient;

    public ObjetosCelestesApiService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<ApiResult<List<ApiRankingObjetoCeleste>>> RankingAsync()
    {
        return _apiClient.GetAsync<List<ApiRankingObjetoCeleste>>("api/objetos-celestes/ranking");
    }
}
