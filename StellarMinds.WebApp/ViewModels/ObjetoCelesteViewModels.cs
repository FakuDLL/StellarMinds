using StellarMinds.WebApp.Services.Api;

namespace StellarMinds.WebApp.ViewModels;

public class RankingObjetosCelestesViewModel
{
    public string? Mensaje { get; set; }
    public List<ApiRankingObjetoCeleste> Ranking { get; set; } = [];
}
