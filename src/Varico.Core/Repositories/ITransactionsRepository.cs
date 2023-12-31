namespace Varico.Core.Repositories;

public interface ITransactionsRepository
{
    Task AddAsync(
        Transaction user,
        CancellationToken ct = default
    );
    
    Task<Transaction?> GetByAsync(
        string referenceId,
        CancellationToken ct = default
    );

    Task<IEnumerable<Transaction>> GetAsync(
        Expression<Func<Transaction, bool>> predicate,
        CancellationToken ct = default
    );
    
    Task UpdateAsync(
        Transaction user,
        CancellationToken ct = default
    );

    Task RemoveAsync(
        Transaction transaction,
        CancellationToken ct = default
    );
}