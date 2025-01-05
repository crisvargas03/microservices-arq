using CartServices.BLL.Features.ExternalServices.BooksApi;

namespace CartServices.BLL.Features.ExternalServices.Interfaces
{
    public interface IBookExternalServices
    {
        Task<BookExternalServicesReponse> GetById(Guid id);
    }
}
