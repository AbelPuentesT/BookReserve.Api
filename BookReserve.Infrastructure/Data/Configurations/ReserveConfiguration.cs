using BookReserve.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReserve.Infrastructure.Data.Configurations
{
    public class ReserveConfiguration : IEntityTypeConfiguration<Reserve>
    {
        public void Configure(EntityTypeBuilder<Reserve> builder)
        {

            builder.HasKey(e => e.Id).HasName("PK__Reserve__3214EC07BCE5A327");

            builder.ToTable("Reserve");

            builder.Property(e => e.Id);

            builder.Property(e => e.BookId).HasColumnName("Book_id");

            builder.Property(e => e.UserId).HasColumnName("User_Id");

            builder.HasOne(d => d.Book).WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserve_Book");

            builder.HasOne(d => d.User).WithMany(p => p.ReservesNavigation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserve_User");
        }
    }
}

