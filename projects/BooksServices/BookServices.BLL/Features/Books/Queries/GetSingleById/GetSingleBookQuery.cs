using BookServices.BLL.Models;
using MediatR;

namespace BookServices.BLL.Features.Books.Queries.GetSingle
{
    public class GetSingleBookQuery : IRequest<APIResponse>
    {
        public Guid Id { get; set; }
    }
}
