using FluentValidation;

namespace BookServices.BLL.Features.Books.Commands.Create
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.AutorId).NotEmpty();
        }
    }
}
