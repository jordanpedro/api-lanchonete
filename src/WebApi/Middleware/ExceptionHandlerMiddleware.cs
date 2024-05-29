using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace ApiLanchonete.Middleware
{ 
    public class  ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string body = string.Empty;
            try
            {
                body = await FormatarRequest(context.Request)
                    .ConfigureAwait(false);
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task<string> FormatarRequest(HttpRequest request)
        {
            request.EnableBuffering();
            request.Body.Position = 0;
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            var stringBody = await reader.ReadToEndAsync();
            request.Body.Position = 0;  
            return stringBody;
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = string.Empty;

            var code = HttpStatusCode.InternalServerError;             

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)code;

            result = JsonConvert.SerializeObject(exception, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            return context.Response.WriteAsync(result);
        }
    }

    [ExcludeFromCodeCoverage]
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandler(this WebApplication app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}