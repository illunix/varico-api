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

    Task<IEnumerable<Account>> GetAsync(CancellationToken ct = default);

    Task UpdateAsync(
        Account acc,
        CancellationToken ct = default
    );
}