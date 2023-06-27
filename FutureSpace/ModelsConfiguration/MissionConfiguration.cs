using FutureSpace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FutureSpace.ModelsConfiguration
{
    public class MissionConfiguration : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.ToTable("missions");
            builder.Property(l => l.Id).IsRequired().HasColumnName("id_mis");
            builder.Property(l => l.LaunchLibraryId).HasColumnName("launch_library_id_mis");
            builder.Property(l => l.Name).HasMaxLength(100).HasColumnName("name_mis");
            builder.Property(l => l.Description).HasMaxLength(200).IsRequired().HasColumnName("description_mis");
            builder.Property(l => l.LaunchDesignator).IsRequired().HasColumnName("launch_designator_mis");
            builder.Property(l => l.Type).HasMaxLength(70).IsRequired().HasColumnName("type_mis");
            builder.Property<int>("OrbitId").HasColumnName("orbit_id_mis");
        }
    }
}
