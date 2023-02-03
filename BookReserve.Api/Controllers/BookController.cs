using AutoMapper;
using BookReserve.Core.DTOs;
using BookReserve.Core.Entities;
using BookReserve.Core.Interfaces;
using BookReserve.Core.QueryFilters;
using Microsoft.AspNetCore.Mvc;

namespace BookReserve.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] BookQueryFilters filters)
        {
            var books = await _bookService.GetAll(filters);
            var booksDTO= _mapper.Map<IEnumerable<BookDTO>>(books);
            return Ok(booksDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var book = await _bookService.GetById(id);
            var bookDTO = _mapper.Map<BookDTO>(book);
            return Ok(bookDTO);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            await _bookService.Insert(book);
            var bookDto = _mapper.Map<BookDTO>(book);
            return Ok(bookDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            book.Id = id;
            var bookDto = await _bookService.Update(book);
            return Ok(bookDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result=await _bookService.Delete(id);
            return Ok(result);
        }

    }
}
