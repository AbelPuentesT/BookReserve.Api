using BookReserve.Core.Entities;

namespace PolizaSOAT.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> BookRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Reserve> ReserveRepository { get; }
        //ISecurityRepository SecurityRepository { get; } 
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
