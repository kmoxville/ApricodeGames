namespace Apricode.ApricodeGames.Data.Configurations
{
    internal sealed class GameGenresConfiguration : IEntityTypeConfiguration<GameGenre>
    {
        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            builder.Property(nameof(GameGenre.Title))
                .IsRequired()
                .HasMaxLength(256);

            builder.HasMany(x => x.Games)
                .WithMany(x => x.Genres);

            builder.HasData(new GameGenre() { Id = 1, Title = "Shooter" });
            builder.HasData(new GameGenre() { Id = 2, Title = "Strategy" });
        }
    }
}
