using System.Net;

namespace StoreApp.Common.Exceptions
{
    public class ApiException : Exception
    {

        public HttpStatusCode Code { get; }
        public ApiException(HttpStatusCode code, string message) : base(message)
        {

            Code = code;
        }
    }
}
