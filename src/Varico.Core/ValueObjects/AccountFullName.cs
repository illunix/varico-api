namespace Varico.Core.ValueObjects;

public sealed record AccountFullName
{
    public string Value { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public AccountFullName(
        string firstName,
        string lastName
    )
    {
        Value = $"{firstName} {lastName}";
        FirstName = firstName;
        LastName = lastName;
    }

    public static implicit operator string(AccountFullName accFullName)
        => accFullName.Value;

    public static implicit operator AccountFullName(string fullName)
    {
        var parts = fullName.Split(' ');
        if (parts.Length != 2)
            throw new ArgumentException(
                "Full name must include first and last name.", 
                nameof(fullName)
            );

        return new AccountFullName(
            parts[0], 
            parts[1]
        );
    }
}