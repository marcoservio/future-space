using FutureSpace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FutureSpace.ModelsConfiguration
{
    public class LaunchServiceProviderConfiguration : IEntityTypeConfiguration<LaunchServiceProvider>
    {
        public void Configure(EntityTypeBuilder<LaunchServiceProvider> builder)
        {
            builder.ToTable("launch_service_providers");
            builder.Property(l => l.Id).IsRequired().HasColumnName("id_lsp");
            builder.Property(l => l.Url).HasMaxLength(100).HasColumnName("url_lsp");
            builder.Property(l => l.Name).HasMaxLength(100).HasColumnName("name_lsp");
            builder.Property(l => l.Type).HasMaxLength(70).IsRequired().HasColumnName("type_lsp");
        }
    }
}
