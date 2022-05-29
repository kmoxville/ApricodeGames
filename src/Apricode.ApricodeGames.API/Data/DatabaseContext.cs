using Apricode.ApricodeGames.API.Data;

namespace Apricode.ApricodeGames.Data
{
    public sealed class DatabaseContext : DbContext
    {
        public DbSet<GameItem> Games { get; set; } = null!;

        public DbSet<GameGenre> Genres { get; set; } = null!;

        public DbSet<DevelopmentStudio> DevelopmentStudios { get; set; } = null!;

        public DbSet<GameItemGameGenre> GameItemGameGenres { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GameItemsConfiguration());
            modelBuilder.ApplyConfiguration(new GameGenresConfiguration());
            modelBuilder.ApplyConfiguration(new DevelopmentStudiosConfiguration());
        }
    }
}
