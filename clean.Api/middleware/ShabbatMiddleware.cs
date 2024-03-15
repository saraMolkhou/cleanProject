using Microsoft.AspNetCore.Http;

namespace clean.Api.middleware
{
    public class ShabbatMiddleware
    {
        private readonly RequestDelegate _next;

        public ShabbatMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var currentDay = DateTime.Now.DayOfWeek;
            if(true)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("האתר שומר שבת");
            }
             await _next(context);
        }
    }
}
