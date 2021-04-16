using CygnetHRD.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CygnetHRD.WebAPI.Filters
{
    public class ValidatorActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (!filterContext.ModelState.IsValid)
            //{
            //    filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
            //}
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var exception = context.Exception as ValidationException;

            if (exception != null)
            {
                var details = new ValidationProblemDetails(exception.Errors)
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                };

                context.Result = new BadRequestObjectResult(details);

                context.ExceptionHandled = true;
            }
        }
    }
}
