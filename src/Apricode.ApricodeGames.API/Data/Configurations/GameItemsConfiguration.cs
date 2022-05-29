namespace Apricode.ApricodeGames.Data.Configurations
{
    internal sealed class GameItemsConfiguration : IEntityTypeConfiguration<GameItem>
    {
        public void Configure(EntityTypeBuilder<GameItem> builder)
        {
            builder.Property(nameof(GameItem.Title))
                .IsRequired()
                .HasMaxLength(256);

            builder.HasOne(x => x.DevelopmentStudio)
                .WithMany(x => x.Games)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Genres)
                .WithMany(x => x.Games)
                .UsingEntity<GameItemGameGenre>();
        }
    }
}
