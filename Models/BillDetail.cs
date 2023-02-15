using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearnASP.Models
{
    public class BillDetail
    {
        public Guid billId { get; set; }
        public Guid productId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public Product? product { get; set; }
        public Bill? bill { get; set; }
    }


    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => new { x.billId, x.productId });
            builder.HasOne(b => b.product).WithMany(b => b.billDetails).HasForeignKey(b => b.productId);
            builder.HasOne(b => b.bill).WithMany(b => b.billDetails).HasForeignKey(b => b.billId);
            builder.Property(x => x.price).IsRequired();
            builder.Property(x => x.quantity).IsRequired();
        }
    }
}
