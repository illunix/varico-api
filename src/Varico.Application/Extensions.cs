namespace Varico.Application;

public static class Extensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
        => services.AddMediator(q => q.ServiceLifetime = ServiceLifetime.Transient);
}