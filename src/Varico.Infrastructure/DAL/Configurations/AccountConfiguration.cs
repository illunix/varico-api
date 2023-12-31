namespace Varico.Infrastructure.DAL.Configurations;

internal sealed class AccountConfiguration : AggregateRootConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);

        builder
            .HasMany(q => q.Transactions)
            .WithOne(q => q.Account)
            .HasForeignKey(q => q.AccountId);
        builder
            .Property(q => q.FullName)
            .HasConversion(
                q => q.ToString(),
                q => AccountFullName.FromFullName(q)
            );
        builder
            .Property(q => q.Balance)
            .HasConversion(
                q => q.Value,
                q => new AccountBalance(q)
            ); 
    }
}