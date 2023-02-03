using BookReserve.Core.Entities;
using BookReserve.Core.QueryFilters;

namespace BookReserve.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Insert(User reserve);
        Task<bool> Update(User reserve);
        Task<bool> Delete(int id);
    }
}