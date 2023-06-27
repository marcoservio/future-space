using FutureSpace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FutureSpace.ModelsConfiguration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("status");
            builder.Property(l => l.Id).IsRequired().HasColumnName("id_sta");
            builder.Property(l => l.Name).HasMaxLength(60).HasColumnName("name_sta");
        }
    }
}
