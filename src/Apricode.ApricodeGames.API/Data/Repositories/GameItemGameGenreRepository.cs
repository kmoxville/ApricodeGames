using Apricode.ApricodeGames.Data;

namespace Apricode.ApricodeGames.API.Data.Repositories
{
    public sealed class GameItemGameGenreRepository : IRepository<GameItemGameGenre>
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<GameItemGameGenre> _dbSet;

        public GameItemGameGenreRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.GameItemGameGenres;
        }

        public void Delete(params GameItemGameGenre[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IQueryable<GameItemGameGenre> GetAll()
        {
            return _dbSet.AsQueryable()
                .Include(x => x.Genre)
                .Include(x => x.GameItem)
                    .ThenInclude(x => x.DevelopmentStudio);
        }

        public Task<GameItemGameGenre?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(params GameItemGameGenre[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(params GameItemGameGenre[] entities)
        {
            _context.UpdateRange(entities);
        }
    }
}
