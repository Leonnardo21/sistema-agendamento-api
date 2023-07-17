using ConnectHealthApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectHealthApi.Data.Mapping
{
    public class AgendaProfessionalMap : IEntityTypeConfiguration<AgendaProfessionalModel>
    {
        public void Configure(EntityTypeBuilder<AgendaProfessionalModel> builder)
        {
            builder.ToTable("Scheduling_Professional");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.TimeTable)
                .IsRequired();

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.Property(x => x.Local)
                .IsRequired();

            builder.Property(x => x.ProfessionalId)
                .IsRequired();

            builder.HasOne(x => x.Professional)
                .WithMany()
                .HasConstraintName("FK_SchedulingProfessional_ProfessionalId")
                .HasForeignKey(x => x.ProfessionalId);
        }
    }
}