using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.subscriptions.Infrastructure.entity;

public sealed class SubscriptionsEntityConfiguration : IEntityTypeConfiguration<SubscriptionsEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionsEntity> builder)
    {
        builder.ToTable("subscriptions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.PlanId).HasColumnName("plan_id").IsRequired();
        builder.Property(x => x.SubscriptionStatusId).HasColumnName("subscription_status_id").IsRequired();
        builder.Property(x => x.SubscriptionTypeId).HasColumnName("subscription_type_id").IsRequired();
        builder.Property(x => x.PaymentId).HasColumnName("payment_id");
        builder.Property(x => x.StartDate).HasColumnName("start_date").IsRequired();
        builder.Property(x => x.EndDate).HasColumnName("end_date");

        builder.HasOne(x => x.Person)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Plan)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.PlanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SubscriptionStatus)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.SubscriptionStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SubscriptionType)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.SubscriptionTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Payment)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
