using AutorsServices.BLL.Features.BookAutor.Commands.Create;
using AutorsServices.BLL.Features.BookAutor.Queries.GetAll;
using AutorsServices.BLL.Features.BookAutor.Queries.GetSingleById;
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
        public async Task<ActionResult<bool>> Create(CreateBookAutorCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<DAL.Entities.BookAutor>>> GetAll()
        {
            var queryRequest = new GetAllBookAutorQuery();
            return await _mediator.Send(queryRequest);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.Entities.BookAutor>> GetById(Guid id)
        {
            var queryRequest = new GetSingleBookAutorByIdQuery { Id = id };
            return await _mediator.Send(queryRequest);
        }
    }
}
