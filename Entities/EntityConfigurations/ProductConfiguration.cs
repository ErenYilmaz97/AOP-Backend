using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.UnitsInStock).IsRequired();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();


            //SOFT DELETE FILTER
            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}