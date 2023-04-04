using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using Persistence.Configurations;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using DataTests.Options;
using Application.Common.Interfaces;

namespace DataTests.DbContext
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
        public DbSet<Person> Persons { get; set; }

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
            new PersonConfiguration().Configure(modelBuilder.Entity<Person>());
        }
    }
}
