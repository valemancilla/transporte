using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.return_load_suggestions.Infrastructure.entity;

public sealed class ReturnLoadSuggestionsEntityConfiguration : IEntityTypeConfiguration<ReturnLoadSuggestionsEntity>
{
    public void Configure(EntityTypeBuilder<ReturnLoadSuggestionsEntity> builder)
    {
        builder.ToTable("return_load_suggestions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.SuggestedLoadId).HasColumnName("suggested_load_id").IsRequired();
        builder.Property(x => x.Score).HasColumnName("score").HasColumnType("decimal(10,4)").IsRequired();

        builder.HasOne(x => x.Load)
            .WithMany(x => x.ReturnLoadSuggestionsAsSource)
            .HasForeignKey(x => x.LoadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SuggestedLoad)
            .WithMany(x => x.ReturnLoadSuggestionsAsTarget)
            .HasForeignKey(x => x.SuggestedLoadId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
