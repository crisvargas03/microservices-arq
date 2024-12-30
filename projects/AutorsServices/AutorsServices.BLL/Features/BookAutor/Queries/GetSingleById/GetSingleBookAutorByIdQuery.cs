using MediatR;

namespace AutorsServices.BLL.Features.BookAutor.Queries.GetSingleById
{
    public class GetSingleBookAutorByIdQuery : IRequest<DAL.Entities.BookAutor>
    {
        public Guid Id { get; set; }
    }
}
