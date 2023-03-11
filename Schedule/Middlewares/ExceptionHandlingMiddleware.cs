using Newtonsoft.Json;
using Schedule.Exceptions;

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
            catch (DetailedException e)
            {
                await ManageResponse(context, e);
            }
            catch (BadHttpRequestException e)
            {
                await ManageResponse(context, e);
            }
            catch (IOException e)
            {
                await ManageResponse(context, e);
            }

        }
        private static async Task ManageResponse(HttpContext context, IOException ex)
        {
            await SendResponse(context, StatusCodes.Status500InternalServerError, new { error = new { message = ex.Message } });
        }

        private static async Task ManageResponse(HttpContext context, BadHttpRequestException ex)
        {
            await SendResponse(context, ex.StatusCode, new { errors = new { message = ex.Message } });
        }

        private static async Task ManageResponse(HttpContext context, DetailedException ex)
        {
            var response = new { errors = new { message = ex.Message, details = ex.Details } };
            await SendResponse(context, ex.StatusCode, response);
        }

        private static async Task SendResponse(HttpContext context, int statusCode, object descr)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(descr)
                );
        }
    }
}
