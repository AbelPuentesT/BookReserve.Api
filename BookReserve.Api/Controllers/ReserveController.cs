using AutoMapper;
using BookReserve.Core.DTOs;
using BookReserve.Core.Entities;
using BookReserve.Core.Interfaces;
using BookReserve.Core.QueryFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookReserve.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private readonly IReserveService _reserveService;
        private readonly IMapper _mapper;
        public ReserveController(IReserveService reserveService, IMapper mapper)
        {
            _reserveService = reserveService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var reserves = await _reserveService.GetAll();
            var reservesDTO = _mapper.Map<IEnumerable<ReserveDTO>>(reserves);
            return Ok(reservesDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var reserve = await _reserveService.GetById(id);
            var reserveDTO = _mapper.Map<ReserveDTO>(reserve);
            return Ok(reserveDTO);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(ReserveDTO reserveDTO)
        {
            var reserve = _mapper.Map<Reserve>(reserveDTO);
            await _reserveService.Insert(reserve);
            var reserveDto = _mapper.Map<ReserveDTO>(reserve);
            return Ok(reserveDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ReserveDTO reserveDTO)
        {
            var reserve = _mapper.Map<Reserve>(reserveDTO);
            reserve.Id = id;
            var reserveDto= await _reserveService.Update(reserve);
            return Ok(reserveDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reserveService.Delete(id);
            return Ok();
        }

    }
}
