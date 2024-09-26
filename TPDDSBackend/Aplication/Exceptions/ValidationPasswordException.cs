using Microsoft.AspNetCore.Identity;
using System.Net;

namespace TPDDSBackend.Aplication.Exceptions
{
    public class ValidationPasswordException: Exception
    {
        public HttpStatusCode statusCode;
        public List<string> Errors;
        public ValidationPasswordException(string message, List<IdentityError> errors) : base(message)
        {
            statusCode = HttpStatusCode.BadRequest;
            Errors = errors.Select(e => e.Description).ToList();
        }
    }
}
