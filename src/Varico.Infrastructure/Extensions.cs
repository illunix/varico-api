namespace Varico.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration cfg
    )
    {
        services.AddPostgres(cfg);
        services.AddRepositories();
        services.AddDataInitializers();
        
        return services;
    }
    
    private static IServiceCollection AddPostgres(
        this IServiceCollection services,
        IConfiguration cfg
    )
    {
        var section = cfg.GetSection(PostgresOptions.SectionName);

        services
            .AddOptions<PostgresOptions>()
            .ValidateOnStart();

        var options = section.Get<PostgresOptions>(); 
        if (options is null)
            throw new ArgumentNullException(nameof(options));

        var connStr = new NpgsqlConnectionStringBuilder
        {
            Host = options.Server,
            Database = options.Database,
            Username = options.User,
            Password = options.Password
        }.ToString();

        services.AddDbContext<VaricoDbContext>(q =>
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

        services.AddHostedService<DatabaseInitializer<VaricoDbContext>>();
        services.AddHostedService<DataInitializer>();

        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .AddScoped<IAccountsRepository, AccountsRepository>()
            .AddScoped<ITransactionsRepository, TransactionsRepository>();

    public static IServiceCollection AddDataInitializers(this IServiceCollection services)
        => services
            .AddInitializer<AccountsInitializer>()
            .AddInitializer<TransactionsInitializer>();

    private static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T :
        class,
        IDataInitializer
        => services.AddTransient<IDataInitializer, T>();
}