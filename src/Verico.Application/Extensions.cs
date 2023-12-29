namespace Verico.Application;

public static class Extensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
        => services.AddHandlers();

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        foreach (var type in typeof(Extensions).Assembly
            .GetTypes()
            .Where(q =>
                q.Name.EndsWith("Handler") &&
                !q.IsAbstract &&
                !q.IsInterface)
            )
            services.AddTransient(type);

        return services;
    }
}