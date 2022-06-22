using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstAPI.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Price).IsRequired();
            builder.Property(s => s.DisplayStatus).IsRequired().HasDefaultValue(true);

        }

    }
}
