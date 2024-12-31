using AutorsServices.DAL.Core.UnitOfWork;
using MediatR;

namespace AutorsServices.BLL.Features.BookAutor.Queries.GetSingleById
{
    public class GetSingleBookAutorByIdQueryHandler : IRequestHandler<GetSingleBookAutorByIdQuery, DAL.Entities.BookAutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleBookAutorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DAL.Entities.BookAutor> Handle(GetSingleBookAutorByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BookAutors.GetAsync(whereExpression: x => x.Id == request.Id);
            if (result is null) 
                return null;

            return result;
        }
    }
}
