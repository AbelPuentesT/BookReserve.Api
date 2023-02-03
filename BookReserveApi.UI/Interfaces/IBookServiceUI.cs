using BookReserve.Core.Entities;
using BookReserve.Core.QueryFilters;

namespace BookReserveApi.UI.Interfaces
{
    public interface IBookServiceUI
    {
        Task<IEnumerable<Book>> GetAll(BookQueryFilters filters);
        Task<Book> GetById(int id);
        Task<Book> Insert(Book book);
        Task<bool> Update(Book book);
        Task<bool> Delete(int id);
    }
}