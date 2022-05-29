namespace Apricode.ApricodeGames.API.Core.Requests.GamesRequests
{
    public class GetGameItemsRequest
    {
        public int? Skip { get; set; } = 0;
        public int? Take { get; set; } = 20;
        public List<int>? GenreIds { get; set; }
    }
}
