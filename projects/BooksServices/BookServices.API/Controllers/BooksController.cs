using BookServices.BLL.Features.Books.Commands.Create;
using BookServices.BLL.Features.Books.Queries.GetAll;
using BookServices.BLL.Features.Books.Queries.GetSingle;
using BookServices.BLL.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create(CreateBookCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            var request = new GetAllBooksQuery();
            return await _mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> GetById(Guid id)
        {
            var queryRequest = new GetSingleBookQuery { Id = id };
            return await _mediator.Send(queryRequest);
        }
    }
}
