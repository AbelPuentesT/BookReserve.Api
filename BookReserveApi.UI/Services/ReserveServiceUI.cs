using BookReserve.Core.Entities;
using BookReserve.Core.Exceptions;
using BookReserveApi.UI.Interfaces;

namespace BookReserveApi.UI.Services
{
    public class ReserveServiceUI : IReserveServiceUI
    {
        private readonly HttpClient _httpClient;
        public ReserveServiceUI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Reserve>> GetAll()
        {
            var reserves = await _httpClient.GetFromJsonAsync<IEnumerable<Reserve>>($"api/Reserve");
            if (reserves == null)
            {
                throw new BusinessException("Not found");
            }
            return reserves;
        }
        public async Task<Reserve> GetById(int id)
        {
            var reserve = await _httpClient.GetFromJsonAsync<Reserve>($"api/Reserve/{id}");
            if (reserve == null)
            {
                throw new BusinessException("Not found");
            }
            return reserve;

        }
        public async Task<Reserve> Insert(Reserve reserve)
        {
            await _httpClient.PostAsJsonAsync("api/Reserve", reserve);
            return reserve;
        }

        public async Task<bool> Update(Reserve reserve)
        {
            await _httpClient.PutAsJsonAsync($"api/Reserve/{reserve.Id}", reserve);
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Reserve/{id}");
            return true;
        }
    }
}