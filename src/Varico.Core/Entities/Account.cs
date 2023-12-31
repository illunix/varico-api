namespace Varico.Core.Entities;

public sealed class Account : AggregateRoot
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string FullName
        => $"{FirstName} {LastName}";
    public AccountBalance Balance { get; private set; } = null!;   
    public ICollection<Transaction> Transactions = new HashSet<Transaction>();

    private Account() { }

    public Account(
        string firstName,
        string lastname
    )
    {
        FirstName = firstName;
        LastName = lastname;
    }
}