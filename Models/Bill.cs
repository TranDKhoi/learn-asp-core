using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearnASP.Models
{
    public enum BillStatus
    {
        New = 0,
        Payment = 1,
        Completed = 2,
        Cancel = -1,
    }
    public class Bill
    {
        public Guid id { get; set; }
        public DateTime createdAt { get; set; }
        public BillStatus status { get; set; }
        public Guid buyerId { get; set; }
        public User? buyer { get; set; }
        public double totalPrice { get; set; }
        public int totalQuantity { get; set; }
        public ICollection<BillDetail> billDetails { get; set; }

        public Bill()
        {
            id = Guid.NewGuid();
            billDetails = new List<BillDetail>();
        }
    }

    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasOne(b => b.buyer).WithMany(b => b.bills).HasForeignKey(b => b.buyerId);
            builder.Property(x => x.status).IsRequired().HasDefaultValue(BillStatus.New);
            builder.Property(x => x.createdAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.buyerId).IsRequired();
            builder.Property(x => x.totalQuantity).IsRequired();
            builder.Property(x => x.totalPrice).IsRequired();
        }
    }
}
