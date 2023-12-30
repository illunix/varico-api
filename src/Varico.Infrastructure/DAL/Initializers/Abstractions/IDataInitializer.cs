namespace Varico.Infrastructure.DAL.Initializers.Abstractions;

internal interface IDataInitializer
{
    Task InitAsync();
}