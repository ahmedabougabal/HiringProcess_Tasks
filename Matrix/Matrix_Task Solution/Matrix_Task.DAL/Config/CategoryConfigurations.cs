using MAtrixTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Matrix_Task.DAL.Config
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {


        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(c => c.ParentCategory)
              .WithMany(c => c.Subcategories)
              .HasForeignKey(c => c.ParentCategoryId);
        }
    }
}
