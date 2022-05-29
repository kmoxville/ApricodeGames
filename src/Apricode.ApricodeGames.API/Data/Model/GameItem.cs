namespace Apricode.ApricodeGames.API.Data.Model
{
    public sealed class GameItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public DevelopmentStudio DevelopmentStudio { get; set; } = default!;

        public ICollection<GameGenre> Genres { get; set; } = new List<GameGenre>();
    }
}
