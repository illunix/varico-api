namespace Verico.Infrastructure.DAL;

internal sealed class VericoDbContext(DbContextOptions<VericoDbContext> options) : DbContext(options)
{
    public required DbSet<Account> Accounts { get; init; }
    public required DbSet<Transaction> Transactions { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}