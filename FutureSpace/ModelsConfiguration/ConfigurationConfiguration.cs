using FutureSpace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FutureSpace.ModelsConfiguration
{
    public class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.ToTable("configurations");
            builder.Property(l => l.Id).IsRequired().HasColumnName("id_con");
            builder.Property(l => l.LaunchLibraryId).HasMaxLength(40).HasColumnName("launch_library_id_con");
            builder.Property(l => l.Name).HasMaxLength(100).HasColumnName("name_con");
            builder.Property(l => l.Family).HasMaxLength(80).IsRequired().HasColumnName("family_con");
            builder.Property(l => l.FullName).HasMaxLength(100).IsRequired().HasColumnName("full_name_con");
            builder.Property(l => l.Variante).HasMaxLength(10).IsRequired().HasColumnName("variantt_con");
        }
    }
}
