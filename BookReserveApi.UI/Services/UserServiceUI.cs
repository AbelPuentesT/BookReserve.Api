using BookReserve.Core.Entities;
using BookReserve.Core.Exceptions;
using BookReserveApi.UI.Interfaces;

namespace BookReserveApi.UI.Services
{
    public class UserServiceUI : IUserServiceUI
    {
        private readonly HttpClient _httpClient;
        public UserServiceUI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _httpClient.GetFromJsonAsync<IEnumerable<User>>($"api/User");
            if (users == null)
            {
                throw new BusinessException("Not found");
            }
            return users;
        }
        public async Task<User> GetById(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<User>($"api/User/{id}");
            if (user == null)
            {
                throw new BusinessException("Not found");
            }
            return user;

        }
        public async Task<User> Insert(User user)
        {
            await _httpClient.PostAsJsonAsync("api/User", user);
            return user;
        }

        public async Task<bool> Update(User user)
        {
            await _httpClient.PutAsJsonAsync($"api/User/{user.Id}", user);
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/User/{id}");
            return true;
        }
    }
}