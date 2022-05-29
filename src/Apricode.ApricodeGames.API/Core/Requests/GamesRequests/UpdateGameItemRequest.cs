namespace Apricode.ApricodeGames.API.Core.Requests.GamesRequests
{
    public class UpdateGameItemRequest
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int DevepmentStudioId { get; set; }

        public int[] GenreIds { get; set; } = new int[0];
    }
}
