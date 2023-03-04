using Newtonsoft.Json;

namespace Schedule.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
            => _next = next;
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BadHttpRequestException e)
            {
                await Response(
                    context,
                    e.StatusCode,
                    e.Message
                    );
            }
            catch (Exception e)
            {
                await Response(
                    context,
                    StatusCodes.Status500InternalServerError,
                    e.Message
                    );
            }
        }
        private static async Task Response(HttpContext context, int statusCode, string message)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(new {error = message})
                );
        }
    }
}
