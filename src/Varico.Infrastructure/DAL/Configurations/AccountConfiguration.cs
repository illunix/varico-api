namespace Varico.Infrastructure.DAL.Configurations;

internal sealed class AccountConfiguration : AggregateRootConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(q => q.Balance)
            .HasConversion(
                q => q.ToString(),
                q => new AccountFullName.FromFullName(q)
            );
        builder
            .Property(q => q.Balance)
            .HasConversion(
                q => q.Value,
                q => new AccountBalance(q)
            );
        builder
            .HasMany(q => q.Transactions)
            .WithOne(q => q.Account)
            .HasForeignKey(q => q.AccountId);
    }
}