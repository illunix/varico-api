using Verico.Infrastructure.DAL.Repositories;

namespace Verico.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration cfg
    )
    {
        services.AddPostgres(cfg);
        services.AddRepositories();
        
        return services;
    }
    
    private static IServiceCollection AddPostgres(
        this IServiceCollection services,
        IConfiguration cfg
    )
    {
        var section = cfg.GetSection("postgres");
        if (!section.Exists())
            return services;

        var options = section.BindOptions<PostgresOptions>();

        if (string.IsNullOrEmpty(options.Server))
            throw new ArgumentException(nameof(options.Server));
        if (string.IsNullOrEmpty(options.Database))
            throw new ArgumentException(nameof(options.Database));
        if (string.IsNullOrEmpty(options.User))
            throw new ArgumentException(nameof(options.User));
        if (string.IsNullOrEmpty(options.Password))
            throw new ArgumentException(nameof(options.Password));

        var connStr = new NpgsqlConnectionStringBuilder
        {
            Host = options.Server,
            Database = options.Database,
            Username = options.User,
            Password = options.Password
        }.ToString();

        services.Configure<PostgresOptions>(section);
        services.AddDbContext<T, K>(q =>
        {
            q.UseNpgsql(connStr);

            q.ConfigureWarnings(warnings =>
            {
                warnings.Default(WarningBehavior.Log);
                // ignore the RowLimitingOperation warning to prevent this warning
                // at firstordefault or other linq-to-sql operations
                warnings.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning);
            });
        });

        services.AddHostedService<DatabaseInitializer<K>>();
        services.AddHostedService<DataInitializer>();

        services.AddScoped(_ => new NpgsqlConnection(connStr));

        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddScoped<ITransactionsRepository, TransactionsRepository>();
}