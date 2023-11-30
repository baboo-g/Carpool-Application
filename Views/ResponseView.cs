using Microsoft.AspNetCore.Http;
using System.Security.Permissions;

namespace UniRideHubBackend.Views
{
    public class ResponseView<T>
    {
        public string Message { get; set; } 
        public T ResponseData { get; set; }

         public string StatusCode { get; set; }
        public ResponseView(T responseData)
        {
            ResponseData = responseData;
        }
        public ResponseView(string message, string statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public ResponseView(string message, string statusCode,T responseData)
        {
            Message = message;
            ResponseData = responseData;
            StatusCode = statusCode;
        }
    }
}
