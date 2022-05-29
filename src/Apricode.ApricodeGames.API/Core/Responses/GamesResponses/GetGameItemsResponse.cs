namespace Apricode.ApricodeGames.API.Core.Responses.GamesResponses
{
    public class GetGameItemsResponse
    {
        public List<GameItem> Items { get; set; } = null!;

        public long TotalCount { get; set; }
    }
}
