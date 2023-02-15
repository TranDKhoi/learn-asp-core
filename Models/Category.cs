using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnASP.Models
{
    public class Category
    {
        public Guid id { get; set; }
        public String name { get; set; }
        public ICollection<Product> products { get; set; }

        public Category()
        {
            id = Guid.NewGuid();
            name = String.Empty;
            products = new List<Product>();
        }
    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.name).IsRequired().HasMaxLength(20);
        }
    }
}
