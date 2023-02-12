using DrabLibrary.Model;
using DrabLibrary.Model.DTO;
using AutoMapper;

namespace DrabLibrary.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();
        }

    }
}
