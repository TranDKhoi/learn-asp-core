using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnASP.Models
{
    public class Product
    {
        public Guid id { get; set; }
        public String name { get; set; }
        public double price { get; set; }
        public Guid categoryId { get; set; }
        public Category? category { get; set; }
        public ICollection<BillDetail> billDetails { get; set; }
        public Product()
        {
            id = Guid.NewGuid();
            name = String.Empty;
            billDetails = new List<BillDetail>();
        }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.category).WithMany(c => c.products).HasForeignKey(x => x.categoryId);
            builder.Property(x => x.name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.price).IsRequired();
        }
    }
}
