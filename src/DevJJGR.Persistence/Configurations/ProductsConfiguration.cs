using DevJJGR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevJJGR.Persistence.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("TBL_PRODUCTS", "dbo");
            builder.HasKey(x => new { x.ProductId });
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.ModifiedAt).IsRequired();

            builder.Ignore(x => x.Code)
                   .Ignore(x => x.Name);

            // builder.HasOne<Categories>(x => x.Categories)
            //.WithMany(x => x.Products)
            //.HasForeignKey(x => x.ProductId)
            //.OnDelete(DeleteBehavior.NoAction)
            //.IsRequired();
        }
    }
}
