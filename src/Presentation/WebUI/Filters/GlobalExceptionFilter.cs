using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebUI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var ex = context.Exception;

            switch (ex)
            {
                case NullReferenceException nEx:
                case ArgumentNullException aEx:
                    context.Result = new ContentResult()
                    {
                        Content = File.ReadAllText("wwwroot/ErrorPages/error.html"),
                        ContentType = "text/html",
                        StatusCode = 200
                    };

                    break;
                default:
                    context.Result = new ContentResult()
                    {
                        Content = "Server error",
                        ContentType = "text/plain",
                        StatusCode = 200,
                    };
                    break;
            }
        }
    }
}
