using ConnectHealthApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectHealthApi.Data.Mapping
{
    public class ProfessionalMap : IEntityTypeConfiguration<ProfessionalModel>
    {
        public void Configure(EntityTypeBuilder<ProfessionalModel> builder)
        {
            builder.ToTable("Professional");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Gender)
                .HasMaxLength(1)
                .HasColumnType("CHAR");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Especiality)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.CreatedAt)
                .HasColumnType("DATE");

            builder.Property(x => x.IsActive)
                .HasColumnType("BIT");
        }
    }
}