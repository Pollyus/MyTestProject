using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TeamLeaderConfiguration : IEntityTypeConfiguration<TeamLeader>
    {
        public void Configure(EntityTypeBuilder<TeamLeader> builder)
        {
            builder.HasKey(leader => leader.Id);
            builder.Property(leader => leader.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(leader => leader.TesterId)
              .HasMaxLength(45);

        }
    }
}