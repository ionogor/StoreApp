namespace StoreApp.Infrastucture.Middleware
{
    public class Authentification
    {
        private RequestDelegate _next;

        public Authentification(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var query  = context.Request.Query["password"];

            if (string.IsNullOrEmpty(query))
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next(context);
            }
        }
    }

}
