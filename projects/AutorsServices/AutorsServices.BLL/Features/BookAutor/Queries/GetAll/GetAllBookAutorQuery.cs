using MediatR;

namespace AutorsServices.BLL.Features.BookAutor.Queries.GetAll
{
    public class GetAllBookAutorQuery : IRequest<List<DAL.Entities.BookAutor>>
    {
    }
}
