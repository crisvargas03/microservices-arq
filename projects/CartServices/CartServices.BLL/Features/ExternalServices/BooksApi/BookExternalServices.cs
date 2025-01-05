using CartServices.BLL.Features.ExternalServices.Interfaces;
using CartServices.DAL.Core.Interfaces;
using System.Text.Json;

namespace CartServices.BLL.Features.ExternalServices.BooksApi
{
    public class BookExternalServices : IBookExternalServices
    {
        private readonly IHttpClientFactory _clientFactory;
        public BookExternalServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<BookExternalServicesReponse> GetById(Guid id)
        {
            try
            {
                var client = _clientFactory.CreateClient("BooksApi");

                var response = await client.GetAsync($"api/books/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonSerializer.Deserialize<BookExternalServicesReponse>(responseContent)!;
                    return responseData;
                }
                else
                {
                    throw new Exception($"Request Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
