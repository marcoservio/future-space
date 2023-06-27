using FutureSpace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FutureSpace.ModelsConfiguration
{
    public class PadConfiguration : IEntityTypeConfiguration<Pad>
    {
        public void Configure(EntityTypeBuilder<Pad> builder)
        {
            builder.ToTable("pads");
            builder.Property(l => l.Id).IsRequired().HasColumnName("id_pad");
            builder.Property(l => l.Url).HasMaxLength(200).HasColumnName("url_pad");
            builder.Property(l => l.Name).HasMaxLength(100).HasColumnName("name_pad");
            builder.Property(l => l.AgencyId).HasMaxLength(100).HasColumnName("agency_id_pad");
            builder.Property(l => l.InfoUrl).IsRequired().HasColumnName("info_url_pad");
            builder.Property(l => l.WikiUrl).IsRequired().HasColumnName("wiki_url_pad");
            builder.Property(l => l.MapUrl).HasMaxLength(100).IsRequired().HasColumnName("map_url_pad");
            builder.Property(l => l.Latitude).HasMaxLength(100).IsRequired().HasColumnName("latitude_pad");
            builder.Property(l => l.Longitude).HasMaxLength(100).IsRequired().HasColumnName("longitude_pad");
            builder.Property(l => l.MapImage).HasMaxLength(100).IsRequired().HasColumnName("map_image_pad");
            builder.Property(l => l.Total_Launch_Count).HasMaxLength(100).IsRequired().HasColumnName("total_launch_count_pad");
            builder.Property<int>("LocationId").HasColumnName("location_id_pad");
        }
    }
}
