namespace Verico.Infrastructure.DAL.Configurations;

internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(q => q.Id);
        builder
            .Property(q => q.Id)
            .HasConversion(
                q => q.Value,
                q => new TransactionId(q)
            );
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
        builder
            .Property(q => q.Category)
            .HasConversion(
                q => q.Value,
                q => new TransactionCategory(q)
            );
        builder
            .Property(q => q.Amount)
            .HasConversion(
                q => q.Value,
                q => new TransactionAmount(q)
            );
    }
}