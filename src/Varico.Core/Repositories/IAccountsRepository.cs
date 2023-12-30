namespace Varico.Core.Repositories;

public interface IAccountsRepository
{
    Task<AggregateId?> GetIdAsync(
        Guid referenceId,
        CancellationToken ct = default
    );

    Task<Account?> GetByAsync(
        Guid referenceId,
        CancellationToken ct = default
    );
}