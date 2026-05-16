using Microsoft.EntityFrameworkCore;
using Unitofwork.Model;

namespace Unitofwork.Data
{
    public class TestDBContext: DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options)
        {
        }
        public DbSet<Associate> Associates { get; set; }
            public DbSet<OrderHeader> OrderHeaders { get; set; }
            public DbSet<OrderItem> OrderItems { get; set; }
    }

}
