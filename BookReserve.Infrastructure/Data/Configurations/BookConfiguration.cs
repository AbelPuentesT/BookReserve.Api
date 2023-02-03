using BookReserve.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Enumerations;

namespace BookReserve.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasKey(e => e.Id).HasName("PK__Book__3214EC07ADF6505E");

            builder.ToTable("Book");

            builder.Property(e => e.Id);

            builder.Property(e => e.Author)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

            builder.Property(e => e.Image).HasColumnType("image");

            builder.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.BookCategory)
                .HasMaxLength(50)
                .HasMaxLength(50)
                .HasConversion(
                x => x.ToString(),
                x => (Category)Enum.Parse(typeof(Category), x)
                );

            builder.Property(e => e.BookReserve);

            builder.Property(e => e.Days);

        }
    }
}
