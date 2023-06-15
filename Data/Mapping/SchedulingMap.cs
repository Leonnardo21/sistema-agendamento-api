using ConnectHealthApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectHealthApi.Data.Mapping
{
    public class SchedulingMap : IEntityTypeConfiguration<SchedulingModel>
    {
        public void Configure(EntityTypeBuilder<SchedulingModel> builder)
        {
            builder.ToTable("Scheduling");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Date);
            builder.Property(x => x.TimeTable);
            builder.Property(x => x.Duration);
            builder.Property(x => x.Local);
            builder.Property(x => x.UserId);
            builder.Property(x => x.ProfessionalId);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasConstraintName("FK_User_Scheduling")
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Professional)
                .WithMany()
                .HasConstraintName("FK_Professional_Scheduling")
                .HasForeignKey(x => x.ProfessionalId);
        }
    }
}
