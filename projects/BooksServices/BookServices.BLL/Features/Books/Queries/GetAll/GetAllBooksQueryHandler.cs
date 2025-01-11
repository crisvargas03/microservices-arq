using AutoMapper;
using BookServices.BLL.Models;
using BooksServies.DAL.Core.Shared;
using BooksServies.DAL.Core.UnitOfWork;
using MediatR;
using System.Net;

namespace BookServices.BLL.Features.Books.Queries.GetAll
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, APIResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        APIResponse _apiResponse;


        public GetAllBooksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _apiResponse = new APIResponse();
        }
        public async Task<APIResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var paginationArgs = new PaginationArguments();
            var result = await _unitOfWork.Books.GetAllAsync(paginationArgs, false);

            var responseData = _mapper.Map<List<GetAllBooksDto>>(result);
            return _apiResponse.SuccesResponse(HttpStatusCode.OK, responseData);
        }
    }
}
