namespace Verico.Core.Repositories;

public interface IAccountsRepository
{
    Task<AggregateId?> GetIdAsync(
        Guid referenceId,
        CancellationToken ct = default
    );
}