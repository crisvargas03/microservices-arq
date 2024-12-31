using AutoMapper;
using BookServices.BLL.Features.Books.Queries.GetSingle;
using BookServices.BLL.Models;
using BooksServies.DAL.Core.UnitOfWork;
using MediatR;
using System.Net;

namespace BookServices.BLL.Features.Books.Queries.GetSingleById
{
    public class GetSingleBookQueryHandler : IRequestHandler<GetSingleBookQuery, APIResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        APIResponse _apiResponse;

        public GetSingleBookQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _apiResponse = new APIResponse();
        }
        public async Task<APIResponse> Handle(GetSingleBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Books.GetAsync(whereExpression: x => x.Id == request.Id);
            if (result is null)
                return _apiResponse.FailedResponse(HttpStatusCode.NotFound, "not-found");

            var respondeData = _mapper.Map<GetSingleBookDto>(result);
            return _apiResponse.SuccesResponse(HttpStatusCode.OK, respondeData);
        }
    }
}
