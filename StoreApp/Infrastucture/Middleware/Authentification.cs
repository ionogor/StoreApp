namespace StoreApp.Infrastucture.Middleware
{
    // Authentication !!!!
    public class Authentification
    {
        private RequestDelegate _next;

        public Authentification(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // parola => Password!!!!
            var query  = context.Request.Query["parola"];

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
