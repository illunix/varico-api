namespace Varico.Core.Entities;

public sealed class Account : AggregateRoot
{
    public AccountFullName FullName { get; private set; } = null!;
    public AccountBalance Balance { get; private set; } = 0;  
    public ICollection<Transaction> Transactions = new HashSet<Transaction>();

    private Account() { }

    public Account(
        AccountFullName fullName,
        AccountBalance balance
    )
    {
        FullName = fullName;
        Balance = balance;
    }

    public void SubtractFromBalance(TransactionAmount amount)
        => Balance = Balance.Subtract(amount);
}