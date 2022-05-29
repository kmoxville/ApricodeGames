namespace Apricode.ApricodeGames.Data.Repositories
{
    public sealed class GameGenresRepository : IRepository<GameGenre>
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<GameGenre> _dbSet;

        public GameGenresRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Genres;
        }

        public void Delete(params GameGenre[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IQueryable<GameGenre> GetAll()
        {
            return _dbSet.AsQueryable().OrderBy(x => x.Id);
        }

        public async Task<GameGenre?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(params GameGenre[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(params GameGenre[] entities)
        {
            _context.UpdateRange(entities);
        }
    }
}
