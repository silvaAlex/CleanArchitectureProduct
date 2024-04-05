using CleanArchitectureProduct.Communication.Response;
using CleanArchitectureProduct.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CleanArchitectureProduct.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            bool result = context.Exception is CleanArchitectureProductException;

            if (result)
            {
                HandleException(context);
            }
            else
            {
                ThrowUnknownError(context);
            }
        }

        private void HandleException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new NotFoundObjectResult(new ResponseErrorJSON(context.Exception.Message));
            }
            else if (context.Exception is ErrorOnValidateException) { }
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJSON(context.Exception.Message));
            }
        }

        private void ThrowUnknownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJSON("Unknown error"));
        }
    }
}
