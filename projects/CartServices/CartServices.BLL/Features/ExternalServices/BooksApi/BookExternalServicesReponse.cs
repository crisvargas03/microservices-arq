namespace CartServices.BLL.Features.ExternalServices.BooksApi
{
    public class Payload
    {
        public string title { get; set; } = string.Empty;
        public DateTime publishDate { get; set; }
        public string autorId { get; set; } = string.Empty;
    }

    public class BookExternalServicesReponse
    {
        public int statusCode { get; set; }
        public bool isSuccess { get; set; }
        public object errorMessages { get; set; } 
        public Payload payload { get; set; }
    }


}
