using FluentValidation;

namespace AutorsServices.BLL.Features.BookAutor.Commands.Create
{
    public class CreateBoolAutorValidator : AbstractValidator<CreateBookAutorCommand>
    {
        public CreateBoolAutorValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("Can be Empty or Null");
            RuleFor(x => x.LastName)
                .NotNull().NotEmpty().WithMessage("Can be Empty or Null");
            RuleFor(x => x.Email)
                .NotNull().NotEmpty().WithMessage("Can be Empty or Null");
        }
    }
}
