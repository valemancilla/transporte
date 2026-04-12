using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.person_plans.Infrastructure.entity;

public sealed class PersonPlansEntityConfiguration : IEntityTypeConfiguration<PersonPlansEntity>
{
    public void Configure(EntityTypeBuilder<PersonPlansEntity> builder)
    {
        builder.ToTable("person_plans");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.PlanId).HasColumnName("plan_id").IsRequired();
        builder.Property(x => x.StartDate).HasColumnName("start_date").IsRequired();
        builder.Property(x => x.EndDate).HasColumnName("end_date");

        builder.HasOne(x => x.Person)
            .WithMany(x => x.PersonPlans)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Plan)
            .WithMany(x => x.PersonPlans)
            .HasForeignKey(x => x.PlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
