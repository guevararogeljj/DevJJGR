using DevJJGR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevJJGR.Persistence.Configurations
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("TBL_CATEGORIES", "dbo");
            builder.HasKey(x => new { x.CategoryId });
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.ModifiedAt).IsRequired();
            builder
                .Ignore(x => x.Code);


        }
    }
}
