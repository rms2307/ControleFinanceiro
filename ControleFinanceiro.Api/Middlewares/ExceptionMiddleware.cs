using ControleFinanceiro.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ControleFinanceiro.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);

            var result = new ProblemDetails
            {
                Title = exception.GetType().Name,
                Instance = context.Request.Path,
                Detail = exception.Message,
                Status = context.Response.StatusCode,
                Type = "about:blank",
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(result,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                }));
        }

        private static int GetStatusCode(Exception ex)
        {
            return ex switch
            {
                BadRequestException _ => (int)HttpStatusCode.BadRequest,
                NotFoundException _ => (int)HttpStatusCode.NotFound,
                UnauthorizedException _ => (int)HttpStatusCode.Unauthorized,
                ForbiddenException _ => (int)HttpStatusCode.Forbidden,
                ConflictException _ => (int)HttpStatusCode.Conflict,
                ServiceUnavailableException _ => (int)HttpStatusCode.ServiceUnavailable,
                InternalServerErrorException _ => (int)HttpStatusCode.InternalServerError,
                _ => (int)HttpStatusCode.InternalServerError,
            };
        }
    }
}