namespace Verico.Infrastructure.Options;

internal sealed record PostgresOptions
{
    public const string SectionName = "postgres";

    public required string Server { get; init; }
    public required string Database { get; init; }
    public required string User { get; init; }
    public required string Password { get; init; }
}