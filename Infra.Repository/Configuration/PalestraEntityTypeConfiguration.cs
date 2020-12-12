using DesignPatternSamples.Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignPatternSamples.Infra.Repository.Configuration
{
    public class PalestraEntityTypeConfiguration : IEntityTypeConfiguration<Palestra>
    {
        public void Configure(EntityTypeBuilder<Palestra> builder)
        {
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(o => o.Titulo).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Palestrante).IsRequired().HasMaxLength(50);
            builder.Property(o => o.GitHub).HasMaxLength(250);
        }
    }
}

