using Application.Common.Interfaces;
using Domain.Entities;
using Persistence.Options;
using Microsoft.Extensions.Options;
using Npgsql;
using Persistence.Configurations;
using Microsoft.EntityFrameworkCore;


namespace Persistence.DbContext
{
    public class TestAppDbContext : Microsoft.EntityFrameworkCore.DbContext, ITestAppDbContext
    {
        private readonly PostgresOptions _postgresOptions;

        public TestAppDbContext(IOptions<PostgresOptions> postgresOptions, DbContextOptions options)
            : base(options)
        {
            _postgresOptions = postgresOptions.Value;
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<TestReport> TestReports { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TeamLeader> TeamLeaders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new NpgsqlConnectionStringBuilder
            {
                Host = _postgresOptions.PostgresHost,
                Port = _postgresOptions.PostgresPort,
                Username = _postgresOptions.PostgresUser,
                Password = _postgresOptions.PostgresPassword,
                Database = _postgresOptions.PostgresDataBase
            }.ConnectionString;
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TestConfiguration().Configure(modelBuilder.Entity<Test>());
            new TestReportConfiguration().Configure(modelBuilder.Entity<TestReport>());
            new PersonConfiguration().Configure(modelBuilder.Entity<Person>());
            new TeamLeaderConfiguration().Configure(modelBuilder.Entity<TeamLeader>());
        }
    }
}
