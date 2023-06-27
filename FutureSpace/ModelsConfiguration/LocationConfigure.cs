using FutureSpace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FutureSpace.ModelsConfiguration
{
    public class LocationConfigure : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("locations");
            builder.Property(l => l.Id).IsRequired().HasColumnName("id_loc");
            builder.Property(l => l.Url).HasMaxLength(100).HasColumnName("url_loc");
            builder.Property(l => l.Name).HasMaxLength(100).HasColumnName("name_loc");
            builder.Property(l => l.CountryCode).HasMaxLength(10).IsRequired().HasColumnName("country_code_loc");
            builder.Property(l => l.MapImage).HasMaxLength(200).IsRequired().HasColumnName("map_image_loc");
            builder.Property(l => l.TotalLaunchCount).IsRequired().HasColumnName("total_launch_count_loc");
            builder.Property(l => l.TotalLandingCount).IsRequired().HasColumnName("total_landing_count_loc");
        }
    }
}
