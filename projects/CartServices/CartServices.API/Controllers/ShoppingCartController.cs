using CartServices.BLL.Features.ShoppingCart.Commands.Create;
using CartServices.BLL.Features.ShoppingCart.Queries.GetShoppingCartDetails;
using CartServices.BLL.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CartServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create(CreateShoppingCartCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> GetDetails(Guid id)
        {
            var request = new GetShoppingCartDetailsQuery{ Id = id };
            return await _mediator.Send(request);
        }
    }
}
