namespace Verico.Core.Repositories;

public interface IAccountsRepository
{
    Task<AggregateId?> GetIdAsync(
        string referenceId,
        CancellationToken ct = default
    );
}