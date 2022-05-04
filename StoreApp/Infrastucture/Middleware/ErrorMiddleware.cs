namespace StoreApp.Infrastucture.Middleware
{
    public class ErrorMiddleware
    {
        private RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            _next(context);
            if(context.Response.StatusCode ==403)
            {
                context.Response.WriteAsync("Access restricted");
            }
        }
    }
}
