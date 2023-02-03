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
    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
