using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookReserve.Core.Entities;

namespace BookReserve.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {


            builder.HasKey(e => e.Id).HasName("PK__User__3214EC07A9A2BAC8");

            builder.ToTable("User");

            builder.Property(e => e.Id);

            builder.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Photo).HasColumnType("image");

            builder.Property(e => e.UserName).HasMaxLength(256);
        }
    }
}
