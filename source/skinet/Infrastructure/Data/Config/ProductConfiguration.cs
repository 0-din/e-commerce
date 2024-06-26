using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18, 2)");
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(b => b.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(b => b.ProductTypeId);
        }
    }
}