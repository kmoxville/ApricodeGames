namespace Apricode.ApricodeGames.API.Data.Model
{
    public sealed class GameItemGameGenre : BaseEntity
    {
        public int GenreId { get; set; }
        public GameGenre Genre { get; set; } = null!;

        public int GameItemId { get; set; }
        public GameItem GameItem { get; set; } = null!;
    }
}
