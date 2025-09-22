using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StaffCelebrationSystemAPI.Models.Formats;
using Microsoft.AspNetCore.Http;

namespace StaffCelebrationSystemAPI.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{ex.GetType()}: {ex.Message}");
                var statusCode = GetStatusCode(ex);

                httpContext.Response.StatusCode = statusCode;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    ErrorMessage = ex.Message,
                    StatusCode = statusCode.ToString(),
                };

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(ResponseFormat.FailureMessageWithData("Action Failed!!!", error)));
            }
        }

        private static int GetStatusCode(Exception ex)
        {
            int statusCode;

            if (ex is OperationCanceledException)
            {
                statusCode = (int)HttpStatusCode.RequestTimeout;
            }
            else if (ex is UnauthorizedAccessException)
            {
                statusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (ex is KeyNotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
            }
            else if (ex is ArgumentException || ex is InvalidOperationException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (ex is NotImplementedException)
            {
                statusCode = (int)HttpStatusCode.NotImplemented;
            }
            else
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
            }

            return statusCode;
        }

    }
}
