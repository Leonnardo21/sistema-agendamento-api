using ConnectHealthApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectHealthApi.Data.Mapping
{
    public class AgendaProfessionalMap : IEntityTypeConfiguration<AgendaProfessionalModel>
    {
        public void Configure(EntityTypeBuilder<AgendaProfessionalModel> builder)
        {
            builder.ToTable("Agenda_Professional");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Date);
            builder.Property(x => x.TimeTable);
            builder.Property(x => x.Duration);
            builder.Property(x => x.Local);
            builder.Property(x => x.ProfessionalId);

            builder.HasOne(x => x.Professional)
                .WithMany()
                .HasConstraintName("FK_AgendaProfessional_ProfessionalId")
                .HasForeignKey(x => x.ProfessionalId);
        }
    }
}