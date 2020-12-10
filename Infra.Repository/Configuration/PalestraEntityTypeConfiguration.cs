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
            builder.Property(o => o.Titulo).IsRequired().HasMaxLength(50);
            builder.Property(o => o.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(o => o.DataInicio).IsRequired();
            builder.Property(o => o.DataTermino).IsRequired();
            builder.Ignore(o => o.Duracao);
            builder.Property(o => o.Instrutor);
            builder.Property(o => o.GitHub);
        }
    }
}