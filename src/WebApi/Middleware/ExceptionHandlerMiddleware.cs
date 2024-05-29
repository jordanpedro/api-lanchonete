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
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            string bodyRequest = string.Empty;
            try
            {
                bodyRequest = await FormatarRequest(context.Request).ConfigureAwait(false);
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, bodyRequest);
            }
        }

        private static async Task<string> FormatarRequest(HttpRequest request)
        {
            request.EnableBuffering();

            request.Body.Position = 0;

            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            var stringBody = await reader.ReadToEndAsync();

            request.Body.Position = 0;  //resetando ponteiro do stream

            return stringBody;
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, string bodyRequest)
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
        public static IApplicationBuilder UseCustomExceptionHandler(this WebApplication app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}