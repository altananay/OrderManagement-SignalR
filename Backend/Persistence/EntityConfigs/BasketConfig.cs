using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigs;

public class BasketConfig : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.ToTable("Baskets").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.ProductPrice).HasColumnName("ProductPrice");
        builder.Property(b => b.ProductCount).HasColumnName("ProductCount");
        builder.Property(n => n.TotalPrice).HasColumnName("TotalPrice");
        builder.Property(n => n.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(n => n.TableId).HasColumnName("TableId").IsRequired();

        builder.HasOne(b => b.Table);
        builder.HasOne(b => b.Product);
    }
}