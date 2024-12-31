using AutoMapper;
using BookServices.BLL.Features.Books.Queries.GetAll;
using BookServices.BLL.Features.Books.Queries.GetSingleById;
using BooksServies.DAL.Entites;

namespace BookServices.BLL.MappingProfiles.Books
{
    public class BooksMappingProfle : Profile
    {
        public BooksMappingProfle()
        {
            CreateMap<GetAllBooksDto, MaterialBooks>().ReverseMap();
            CreateMap<GetSingleBookDto, MaterialBooks>().ReverseMap();
        }
    }
}
