using FutureSpace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FutureSpace.ModelsConfiguration
{
    public class OrbitConfiguration : IEntityTypeConfiguration<Orbit>
    {
        public void Configure(EntityTypeBuilder<Orbit> builder)
        {
            builder.ToTable("orbits");
            builder.Property(l => l.Id).IsRequired().HasColumnName("id_orb");
            builder.Property(l => l.Name).HasMaxLength(70).HasColumnName("name_orb");
            builder.Property(l => l.Abbrev).HasMaxLength(10).IsRequired().HasColumnName("abbrev_orb");
        }
    }
}
