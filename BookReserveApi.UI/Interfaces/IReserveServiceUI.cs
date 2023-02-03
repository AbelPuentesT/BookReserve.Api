using BookReserve.Core.Entities;

namespace BookReserveApi.UI.Interfaces
{
    public interface IReserveServiceUI
    {
        Task<IEnumerable<Reserve>> GetAll();
        Task<Reserve> GetById(int id);
        Task<Reserve> Insert(Reserve reserve);
        Task<bool> Update(Reserve reserve);
        Task<bool> Delete(int id);
    }
}