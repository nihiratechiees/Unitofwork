using Microsoft.EntityFrameworkCore;

namespace Unitofwork.Data
{
    public class TestDBContext: DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options)
        {
        }
        public DbSet<Model.Associate> Associates { get; set; }
    }
}
