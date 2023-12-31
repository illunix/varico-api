namespace Varico.Infrastructure.DAL.Initializers;

internal sealed class DataInitializer(
    IServiceProvider serviceProvider,
    ILogger<DataInitializer> logger
) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();

        var initializers = scope.ServiceProvider.GetServices<IDataInitializer>();

        foreach (var initializer in initializers) 
        {
            try
            {
                logger.LogInformation($"Running the initializer: {initializer.GetType().Name}...");
                await initializer.InitAsync();
            }
            catch (Exception ex) 
            {
                logger.LogError(
                    ex,
                    ex.Message
                );
            }
        }
    }

    public Task StopAsync(CancellationToken ct)
        => Task.CompletedTask;
}