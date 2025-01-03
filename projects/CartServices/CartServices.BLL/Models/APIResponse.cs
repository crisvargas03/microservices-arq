using System.Net;

namespace CartServices.BLL.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string>? ErrorMessages { get; set; }
        public object? Payload { get; set; }

        public APIResponse()
        {
            ErrorMessages = new List<string>();
            IsSuccess = true;
            StatusCode = HttpStatusCode.OK;
        }
        public APIResponse FailedResponse(HttpStatusCode statusCode, string error)
        {
            return new APIResponse
            {
                StatusCode = statusCode,
                Payload = null,
                IsSuccess = false,
                ErrorMessages = [error]
            };
        }

        public APIResponse SuccesResponse(HttpStatusCode statusCode, object payload)
        {
            return new APIResponse
            {
                StatusCode = statusCode,
                Payload = payload,
                IsSuccess = true,
                ErrorMessages = null
            };
        }
    }
}
