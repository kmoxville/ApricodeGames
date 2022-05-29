namespace Apricode.ApricodeGames.Data.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabaseContext(
            this IServiceCollection services, IConfiguration config, bool isDevelopment)
        {
            var options = config.GetSection(MySqlOptions.Position).Get<MySqlOptions>();
            var connectionString = options.GetConnectionString();
            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

            services.AddDbContext<DatabaseContext>(
                dbContextOptions =>
                {
                    dbContextOptions.UseMySql(connectionString, serverVersion)
                        .EnableDetailedErrors();

                    if (isDevelopment)
                    {
                        dbContextOptions.LogTo(Console.WriteLine, LogLevel.Information)
                            .EnableSensitiveDataLogging();
                    }
                    else
                    {
                        dbContextOptions.LogTo(Console.WriteLine, LogLevel.Warning)
                            .EnableSensitiveDataLogging();
                    }
                });

            return services;
        }
    }
}
