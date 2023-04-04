using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests.Configuration
{
    internal class TestReportConfiguration
    {
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TestReportConfiguration : IEntityTypeConfiguration<TestReport>
    {
        public void Configure(EntityTypeBuilder<TestReport> builder)
        {
            builder.HasKey(report => report.Id);
            builder.Property(report => report.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(report => report.xmlReport)
                .HasMaxLength(10000);

            builder.Property(report => report.htmlReport)
              .HasMaxLength(10000);

            builder.Property(report => report.JobId)
               .IsRequired()
               .HasMaxLength(45);

            builder.Property(report => report.PipelineId)
               .IsRequired()
               .HasMaxLength(45);
        }
    }