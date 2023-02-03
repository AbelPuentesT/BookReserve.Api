using AutoMapper;
using BookReserve.Core.DTOs;
using BookReserve.Core.Entities;
using BookReserve.Core.Interfaces;
using BookReserve.Core.QueryFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReserve.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var users = await _userService.GetAll();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(usersDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userService.GetById(id);
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userService.Insert(user);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Id = id;
            var userDto= await _userService.Update(user);
            return Ok(userDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }

    }
}