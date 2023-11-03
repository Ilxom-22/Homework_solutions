using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var problemDetails = context.Exception switch
        {
            ArgumentException => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Detail = context.Exception.Message
            },
            InvalidOperationException => new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Detail = context.Exception.Message
            },
            Exception => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError, 
                Detail = context.Exception.Message
            }
        };

        context.ExceptionHandled = true;

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }
}