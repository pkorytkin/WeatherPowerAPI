using Power.DTO;
using WeatherAPI.Exceptions;

namespace Power.Middlewares
{
    /// <summary>
    /// Модлвеир для перехвата ошибок
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode;
            string message;

            switch (exception)
            {
                case WeatherAPIException notFoundEx:
                    statusCode = StatusCodes.Status500InternalServerError;
                    message = "Ошибка при получении ответа от WeatherAPI.";
                    break;
                case NullReferenceException notFoundEx:
                    statusCode = StatusCodes.Status500InternalServerError;
                    message = "Что-то пошло не так.";
                    break;


                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    message = "An unexpected error occurred.";
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var result = System.Text.Json.JsonSerializer.Serialize(new ErrorDTO(message));
            return context.Response.WriteAsync(result);
        }
    }
}
