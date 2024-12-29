using AutorsServices.BLL.Features.BookAutor.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutorsServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookAutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateBookAutorCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
