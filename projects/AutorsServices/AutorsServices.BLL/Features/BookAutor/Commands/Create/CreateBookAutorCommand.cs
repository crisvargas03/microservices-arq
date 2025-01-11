using MediatR;

namespace AutorsServices.BLL.Features.BookAutor.Commands.Create
{
    public class CreateBookAutorCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
    }
}
