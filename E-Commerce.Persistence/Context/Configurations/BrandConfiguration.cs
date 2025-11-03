using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Commerce.Domain.Entities.Products;

namespace E_Commerce.Persistence.Context.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(b => b.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(256);
        }
    }
}
