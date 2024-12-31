using AutorsServices.DAL.Core.UnitOfWork;
using MediatR;

namespace AutorsServices.BLL.Features.BookAutor.Queries.GetAll
{
    public class GetAllBookAutorQueryHandler : IRequestHandler<GetAllBookAutorQuery, List<DAL.Entities.BookAutor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBookAutorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DAL.Entities.BookAutor>> Handle(GetAllBookAutorQuery request, CancellationToken cancellationToken)
        {
            var paginationArg = new DAL.Core.PaginationArguments();
            var result = await _unitOfWork.BookAutors.GetAllAsync(paginationArg);

            return result.ToList();
        }
    }
}
