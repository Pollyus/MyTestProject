
using Microsoft.EntityFrameworkCore;

namespace TestAppData
{
    //Контекст базы данных 
    public class TestAppContext : DbContext
    {
        public DbSet<TestResult> TestResults { get; set; }
        public TestAppContext(DbContextOptions<TestAppContext> options):
            base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        
    }
}
