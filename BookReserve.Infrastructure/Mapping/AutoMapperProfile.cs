using AutoMapper;
using BookReserve.Core.DTOs;
using BookReserve.Core.Entities;

namespace BookReserve.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Reserve, ReserveDTO>().ReverseMap();
        }
    }
}
