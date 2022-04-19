namespace StoreApp.Infrastucture.Middleware
{
    public class Routing
    {
        private RequestDelegate _next;

        public Routing(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
           string route = context.Request.Path;
            if(route == "/" || route == "/home")
            { //www.test.com
                await context.Response.WriteAsync("Home page");
          
               
            }
        }
    }
}
