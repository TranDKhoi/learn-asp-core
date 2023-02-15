using Microsoft.EntityFrameworkCore;

namespace LearnASP.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //DbSet
        public DbSet<Product> Product => Set<Product>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<Bill> Bill => Set<Bill>();
        public DbSet<BillDetail> BillDetail => Set<BillDetail>();
        public DbSet<User> User => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
