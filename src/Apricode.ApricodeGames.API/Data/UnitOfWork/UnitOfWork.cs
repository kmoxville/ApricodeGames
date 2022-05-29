using Apricode.ApricodeGames.API.Data.Repositories;
using Apricode.ApricodeGames.Data;
using Apricode.ApricodeGames.Data.Repositories;
using Apricode.ApricodeGames.Data.Repositries;

namespace Apricode.ApricodeGames.API.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            Genres = new GameGenresRepository(context);
            Games = new GamesRepository(context);
            DevelopmentStudios = new DevelopmentStudiosRepository(context);
            GamesGenres = new GameItemGameGenreRepository(context);

            _context = context;
        }

        public IRepository<GameGenre> Genres { get; private set; }

        public IRepository<GameItem> Games { get; private set; }

        public IRepository<DevelopmentStudio> DevelopmentStudios { get; private set; }

        public IRepository<GameItemGameGenre> GamesGenres { get; private set; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IRepository<GameItem>, GamesRepository>();
            services.AddScoped<IRepository<GameGenre>, GameGenresRepository>();
            services.AddScoped<IRepository<DevelopmentStudio>, DevelopmentStudiosRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
