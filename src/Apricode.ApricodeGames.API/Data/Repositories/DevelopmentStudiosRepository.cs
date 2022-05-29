namespace Apricode.ApricodeGames.Data.Repositories
{
    public sealed class DevelopmentStudiosRepository : IRepository<DevelopmentStudio>
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<DevelopmentStudio> _dbSet;

        public DevelopmentStudiosRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.DevelopmentStudios;
        }

        public void Delete(params DevelopmentStudio[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IQueryable<DevelopmentStudio> GetAll()
        {
            return _dbSet.AsQueryable().OrderBy(x => x.Id);
        }

        public async Task<DevelopmentStudio?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(params DevelopmentStudio[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(params DevelopmentStudio[] entities)
        {
            _context.UpdateRange(entities);
        }
    }
}
