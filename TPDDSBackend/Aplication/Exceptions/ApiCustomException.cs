using System.Net;

namespace TPDDSBackend.Aplication.Exceptions
{
    public class ApiCustomException : Exception
    {
        public HttpStatusCode statusCode;
        public ApiCustomException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            statusCode = httpStatusCode;
        }
    }
}
