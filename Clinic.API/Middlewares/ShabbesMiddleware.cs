namespace Clinic.API.Middlewares
{
    public class ShabbesMiddleware
    {
        private readonly RequestDelegate _next;

        public ShabbesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isShabbat = false;
            if(isShabbat)
            {
                context.Response.StatusCode = 400;
            }
            else
            {
                await _next(context);
            }
        }
    }
}
