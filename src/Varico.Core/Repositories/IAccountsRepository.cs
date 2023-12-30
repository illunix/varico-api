namespace Varico.Core.Repositories;

public interface IAccountsRepository
{
    Task<AggregateId?> GetIdAsync(
        string referenceId,
        CancellationToken ct = default
    );

    Task<Account?> GetByAsync(
        string referenceId,
        CancellationToken ct = default
    );
}