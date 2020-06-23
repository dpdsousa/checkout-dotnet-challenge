using CheckoutChallenge.PaymentGateway.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.WebApi.Core.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(
            RequestDelegate next, 
            ILogger<CustomExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is BusinessException businessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;

                var errorMessage = JsonConvert.SerializeObject(new ConflictMessage
                {
                    Code = businessException.ExceptionCode,
                    Message = businessException.Message
                }, Formatting.None);

                return context.Response.WriteAsync(errorMessage);
            }

            if (exception is ValidationException validationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errors = new Queue<BadRequestMessage.PropertyError>();
                foreach (var validationError in validationException.Errors)
                {
                    errors.Enqueue(new BadRequestMessage.PropertyError
                    {
                        PropertyName = validationError.PropertyName,
                        Errors = validationError.ErrorMessages.ToArray()
                    });
                }

                var validationErrorMessage = JsonConvert.SerializeObject(new BadRequestMessage{ Errors = errors }, Formatting.None);
                return context.Response.WriteAsync(validationErrorMessage);
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var internalErrorMessage = JsonConvert.SerializeObject(new { Message = "Internal server error" }, Formatting.None);
            return context.Response.WriteAsync(internalErrorMessage);
        }
    }
}
