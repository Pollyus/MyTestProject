using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Application.Common.Interfaces
{
    public interface ITestAppDbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TeamLeader> TeamLeaders { get; set; }
        public DbSet<TestReport> TestReports { get; set; }
    }
}
