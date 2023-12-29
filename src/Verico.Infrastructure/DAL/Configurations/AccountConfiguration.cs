namespace Verico.Infrastructure.DAL.Configurations;

internal sealed class AccountConfiguration : AggregateRootConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);
        
        builder
            .HasMany(q => q.Transactions)
            .WithOne(q => q.Account)
            .HasForeignKey(q => q.AccountId);
    }        
}