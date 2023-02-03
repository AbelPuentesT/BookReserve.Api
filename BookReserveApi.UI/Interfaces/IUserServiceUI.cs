using BookReserve.Core.Entities;

namespace BookReserveApi.UI.Interfaces
{
    public interface IUserServiceUI
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Insert(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
    }
}