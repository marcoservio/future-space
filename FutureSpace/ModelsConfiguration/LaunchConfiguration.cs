using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FutureSpace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FutureSpace.ModelsConfiguration
{
    public class LaunchConfiguration : IEntityTypeConfiguration<Launch>
    {
        public void Configure(EntityTypeBuilder<Launch> builder)
        {
            builder.ToTable("launchers");
            builder.Property(l => l.Id).HasMaxLength(40).IsRequired().HasColumnName("id_lau");
            builder.Property(l => l.Url).HasMaxLength(200).HasColumnName("url_lau");
            builder.Property(l => l.LaunchLibraryId).HasColumnName("launch_library_id_lau");
            builder.Property(l => l.Slug).HasMaxLength(100).HasColumnName("slug_lau");
            builder.Property(l => l.Name).HasMaxLength(100).IsRequired().HasColumnName("name_lau");
            builder.Property(l => l.Net).IsRequired().HasColumnName("net_lau");
            builder.Property(l => l.WindowEnd).IsRequired().HasColumnName("window_end_lau");
            builder.Property(l => l.WindowStart).IsRequired().HasColumnName("window_start_lau");
            builder.Property(l => l.Inhold).IsRequired().HasColumnName("inhold_lau");
            builder.Property(l => l.TbdTime).IsRequired().HasColumnName("tbdtime_lau");
            builder.Property(l => l.TbdDate).IsRequired().HasColumnName("tbddate_lau");
            builder.Property(l => l.Probability).HasColumnName("probability_lau");
            builder.Property(l => l.HoldReason).HasMaxLength(200).HasColumnName("holdreason_lau");
            builder.Property(l => l.FailReason).HasMaxLength(200).HasColumnName("failreason_lau");
            builder.Property(l => l.Hashtag).HasMaxLength(100).HasColumnName("hashtag_lau");
            builder.Property(l => l.WebcastLive).HasColumnName("webcast_live_lau");
            builder.Property(l => l.Image).HasMaxLength(200).HasColumnName("image_lau");
            builder.Property(l => l.Infographic).HasColumnName("infographic_lau");
            builder.Property(l => l.Program).HasColumnName("program_lau");

            builder.Property<int>("StatusId").HasColumnName("status_id_lau");
            builder.Property<int>("LaunchServiceProviderId").HasColumnName("launch_dervice_provider_id_lau");
            builder.Property<int>("RocketId").HasColumnName("rocket_id_lau");
            builder.Property<int>("MissionId").HasColumnName("mission_id_lau");
            builder.Property<int>("PadId").HasColumnName("pad_id_lau");
        }
    }
}
