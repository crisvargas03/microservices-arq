using BookServices.BLL.Models;
using MediatR;

namespace BookServices.BLL.Features.Books.Commands.Create
{
    public class CreateBookCommand : IRequest<APIResponse>
    {
        public string Title { get; set; } = string.Empty;
        public DateTime? PublishDate { get; set; }
        public Guid AutorId { get; set; }
    }
}
