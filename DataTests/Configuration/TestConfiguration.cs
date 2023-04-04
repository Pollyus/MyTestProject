using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataTests.Configurations

{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(test => test.Id);
            builder.Property(test => test.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(test => test.Job)
                .IsRequired()
                .HasMaxLength(45);


            builder.Property(test => test.Pipeline)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(test => test.Namespace)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
