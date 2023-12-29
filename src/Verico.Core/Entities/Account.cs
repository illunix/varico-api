namespace Verico.Core.Entities;

public sealed class Account : AggregateRoot
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
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