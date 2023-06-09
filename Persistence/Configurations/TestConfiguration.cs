﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(test => test.Id);
            builder.Property(test => test.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.HasKey(test => test.Name);
            builder.Property(test => test.Name)
                .IsRequired();

            builder.Property(test => test.Namespace)
                .HasMaxLength(45);

            builder.Property(test => test.Pipeline)
              .IsRequired()
              .HasMaxLength(45);

            builder.Property(test => test.Job)
               .IsRequired()
               .HasMaxLength(45);
        }
    }
}