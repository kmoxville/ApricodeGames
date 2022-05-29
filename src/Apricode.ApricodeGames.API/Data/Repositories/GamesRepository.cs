namespace Apricode.ApricodeGames.Data.Repositries
{
    public sealed class GamesRepository : IRepository<GameItem>
    {
        private readonly DatabaseContext _context;

        public GamesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Delete(params GameItem[] entities)
        {
            _context.Games.RemoveRange(entities);
        }

        public IQueryable<GameItem> GetAll()
        {
            return _context.Games
                .Include(x => x.Genres)
                .Include(x => x.DevelopmentStudio)
                .OrderBy(x => x.Id)
                .AsQueryable();
        }

        public async Task<GameItem?> GetByIdAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(params GameItem[] entities)
        {
            await _context.Games.AddRangeAsync(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(params GameItem[] entities)
        {
            _context.UpdateRange(entities);
        }
    }
}
