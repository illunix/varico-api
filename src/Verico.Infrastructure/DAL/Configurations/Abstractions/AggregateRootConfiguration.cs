namespace Verico.Infrastructure.DAL.Configurations.Abstractions;

public abstract class AggregateRootConfiguration<TBase> : IEntityTypeConfiguration<TBase>
    where TBase : AggregateRoot
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.HasKey(q => q.Id);
        builder
            .Property(q => q.Id)
            .HasConversion(
                q => q.Value,
                q => new AggregateId(q)
            );
        builder
            .Property(q => q.ReferenceId)
            .HasConversion(
                q => q.Value,
                q => new AggregateReferenceId(q)
            );
    }
}