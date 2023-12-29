namespace Verico.Core.Repositories;

public interface ITransactionsRepository
{
    Task AddAsync(
        Transaction user,
        CancellationToken ct = default
    );
    
    Task<Transaction?> GetAsync(
        string referenceId,
        CancellationToken ct = default
    );
    
    Task UpdateAsync(
        Transaction user,
        CancellationToken ct = default
    );
}