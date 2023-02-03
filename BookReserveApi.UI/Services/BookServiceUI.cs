using BookReserve.Core.Entities;
using BookReserve.Core.Exceptions;
using BookReserve.Core.QueryFilters;
using BookReserveApi.UI.Interfaces;

namespace BookReserveApi.UI.Services
{
    public class BookServiceUI : IBookServiceUI
    {
        private readonly HttpClient _httpClient;
        public BookServiceUI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetAll(BookQueryFilters filters)
        {
            var books = await _httpClient.GetFromJsonAsync<IEnumerable<Book>>($"api/Book?Title={filters.Title}&BookCategory={filters.BookCategory}");
            if (books == null)
            {
                throw new BusinessException("Not found");
            }
            return books;
        }
        public async Task<Book> GetById(int id)
        {
            var book = await _httpClient.GetFromJsonAsync<Book>($"api/Book/{id}");
            if (book == null)
            {
                throw new BusinessException("Not found");
            }
            return book;

        }
        public async Task<Book> Insert(Book book)
        {
            await _httpClient.PostAsJsonAsync("api/Book", book);
            return book;
        }

        public async Task<bool> Update(Book book)
        {
            await _httpClient.PutAsJsonAsync($"api/Book/{book.Id}", book);
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Book/{id}");
            return true;
        }
    }
}