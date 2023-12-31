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

    public override string ToString()
        => $"{FirstName} {LastName}";

    public static AccountFullName FromFullName(string fullName)
    {
        var parts = fullName.Split(' ');
        if (parts.Length != 2)
            throw new ArgumentException(
                "Full name must include at first and last name.", 
                nameof(fullName)
            );

        return new AccountFullName(
            parts[0], 
            string.Join(
                " ", 
                parts.Skip(1)
            )
        );
    }
}