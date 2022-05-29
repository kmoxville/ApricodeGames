namespace Apricode.ApricodeGames.Data.Configurations
{
    internal sealed class DevelopmentStudiosConfiguration : IEntityTypeConfiguration<DevelopmentStudio>
    {
        public void Configure(EntityTypeBuilder<DevelopmentStudio> builder)
        {
            builder.Property(nameof(DevelopmentStudio.Title))
                .IsRequired()
                .HasMaxLength(256);

            builder.HasMany(x => x.Games)
                .WithOne(x => x.DevelopmentStudio)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new DevelopmentStudio() { Id = 1, Title = "Take2" });
            builder.HasData(new DevelopmentStudio() { Id = 2, Title = "Blizzard" });
            builder.HasData(new DevelopmentStudio() { Id = 3, Title = "Konami" });
        }
    }
}
