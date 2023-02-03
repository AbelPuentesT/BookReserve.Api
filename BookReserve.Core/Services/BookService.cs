using BookReserve.Core.Entities;
using BookReserve.Core.Interfaces;
using BookReserve.Core.QueryFilters;
using PolizaSOAT.Core.Interfaces;

namespace BookReserve.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Book>> GetAll(BookQueryFilters filters)
        {
            var books = _unitOfWork.BookRepository.GetAll();
            if (filters.Title != null)
            {
                books = books.Where(x => x.Title.ToLower().Contains(filters.Title.ToLower()));
            }
            if (filters.BookCategory != null)
            {
                books = books.Where(x => x.BookCategory == filters.BookCategory);
            }
            foreach (var book in books)
            {
                books = books.Where(x => x.BookReserve == false || x.BookReserve == null);
            }
            return books.ToList();
        }
        public async Task<Book> GetById(int id)
        {
            var book = await _unitOfWork.BookRepository.GetById(id);
            if (book == null)
            {
                throw new Exception("Not fount");
            }
            return book;
        }
        public async Task<Book> Insert(Book book)
        {
            await _unitOfWork.BookRepository.Insert(book);
            await _unitOfWork.SaveChangesAsync();
            return book;
        }
        public async Task<bool> Update(Book book)
        {
            var bookExisting = await _unitOfWork.BookRepository.GetById(book.Id);
            bookExisting.Title= book.Title;
            bookExisting.Author= book.Author;
            bookExisting.Description= book.Description;
            bookExisting.Image= book.Image;
            bookExisting.BookCategory= book.BookCategory;
            bookExisting.BookReserve= book.BookReserve;
            bookExisting.Days= book.Days;
            _unitOfWork.BookRepository.Update(bookExisting);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.BookRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}