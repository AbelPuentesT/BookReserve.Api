using BookReserve.Core.Entities;
using BookReserve.Core.QueryFilters;

namespace BookReserve.Core.Interfaces
{
    public interface IReserveService
    {
        Task<IEnumerable<Reserve>> GetAll();
        Task<Reserve> GetById(int id);
        Task<Reserve> Insert(Reserve reserve);
        Task<bool> Update(Reserve reserve);
        Task<bool> Delete(int id);
    }
}