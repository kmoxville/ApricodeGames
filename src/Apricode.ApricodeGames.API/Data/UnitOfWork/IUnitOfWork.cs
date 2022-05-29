namespace Apricode.ApricodeGames.API.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<GameGenre> Genres { get; }
        IRepository<GameItem> Games { get; }
        IRepository<DevelopmentStudio> DevelopmentStudios { get; }
        IRepository<GameItemGameGenre> GamesGenres { get; }

        Task SaveAsync();
    }
}
