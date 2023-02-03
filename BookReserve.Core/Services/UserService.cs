using BookReserve.Core.Entities;
using BookReserve.Core.Interfaces;
using BookReserve.Core.QueryFilters;
using PolizaSOAT.Core.Interfaces;

namespace BookReserve.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            var users = _unitOfWork.UserRepository.GetAll();

            return users.ToList();
        }
        public async Task<User> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                throw new Exception("Not fount");
            }
            return user;
        }
        public async Task<User> Insert(User user)
        {
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }
        public async Task<bool> Update(User user)
        {
            var userExisting = await _unitOfWork.UserRepository.GetById(user.Id);
            _unitOfWork.UserRepository.Update(userExisting);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}