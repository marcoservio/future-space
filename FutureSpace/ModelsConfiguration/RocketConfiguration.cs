using FutureSpace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FutureSpace.ModelsConfiguration
{
    public class RocketConfiguration : IEntityTypeConfiguration<Rocket>
    {
        public void Configure(EntityTypeBuilder<Rocket> builder)
        {
            builder.ToTable("rockets");
            builder.Property(l => l.Id).IsRequired().HasColumnName("id_roc");
            builder.Property<int>("ConfigurationId").HasColumnName("configuration_id_roc");
        }
    }
}
