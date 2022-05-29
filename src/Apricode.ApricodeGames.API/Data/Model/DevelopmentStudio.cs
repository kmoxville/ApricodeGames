namespace Apricode.ApricodeGames.API.Data.Model
{
    public sealed class DevelopmentStudio : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public ICollection<GameItem> Games { get; set; } = new List<GameItem>();
    }
}
