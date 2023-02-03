using BookReserve.Core.Entities;
using BookReserve.Infrastructure.Data;
using PolizaSOAT.Core.Interfaces;

namespace PolizaSOAT.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookReserveContext _context;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Reserve> _reserveRepository;
        //private readonly ISecurityRepository _securityRepository;
        public UnitOfWork(BookReserveContext polizaSoatContext)
        {
            _context = polizaSoatContext;
        }
        public IRepository<Book> BookRepository => _bookRepository ?? new Repository<Book>(_context);

        public IRepository<User> UserRepository => _userRepository ?? new Repository<User>(_context);

        public IRepository<Reserve> ReserveRepository => _reserveRepository ?? new Repository<Reserve>(_context);
        //public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);


        public void Dispose()
        {
            if (_context != null)
            {

                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
