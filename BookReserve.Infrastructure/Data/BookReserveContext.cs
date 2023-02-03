using BookReserve.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookReserve.Infrastructure.Data;

public partial class BookReserveContext : DbContext
{
    public BookReserveContext()
    {
    }

    public BookReserveContext(DbContextOptions<BookReserveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Reserve> Reserves { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-EHT92H8;Initial Catalog=BookReserve;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }

}
