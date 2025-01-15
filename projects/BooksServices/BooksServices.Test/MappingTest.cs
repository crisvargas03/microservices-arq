using AutoMapper;
using BookServices.BLL.Features.Books.Commands.Create;
using BookServices.BLL.Features.Books.Queries.GetAll;
using BooksServies.DAL.Entites;

namespace BooksServices.Test
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<MaterialBooks, GetAllBooksDto>();
            CreateMap<MaterialBooks, CreateBookCommand>();
        }
    }
}
