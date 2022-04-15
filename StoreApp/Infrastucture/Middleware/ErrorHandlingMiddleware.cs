namespace StoreApp.Infrastucture.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next= next;
        }

        public async Task Invoke(HttpContext context)
        {
            // code
        }
    }
}
