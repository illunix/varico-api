namespace Verico.Infrastructure.DAL.Configurations;

internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder
            .Property(q => q.ReferenceId)
            .HasConversion(
                q => q.Value,
                q => new TransactionReferenceId(q)
            );
        builder
            .HasIndex(q => q.ReferenceId)
            .IsUnique();
        builder
            .Property(q => q.AccountId)
            .HasConversion(
                q => q.Value,
                q => new AggregateId(q)
            );
    }
}