using Timelogger.BLL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api.ExceptionHandler
{
    public class ExceptionHandlingFilter : ExceptionFilterAttribute
    {
        readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ExceptionHandlingFilter()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(NotFoundException), HandleNotFoundException},
                { typeof(EntityDuplicateException), HandleEntityDuplicateException}
            };
        }

        public override void OnException(ExceptionContext context)
        {

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();

            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        public void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server error occured while processing your request"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        public void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var details = new ProblemDetails
            {
                Title = "The specified resource was not found",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        public void HandleEntityDuplicateException(ExceptionContext context)
        {
            var exception = context.Exception as EntityDuplicateException;

            var details = new ProblemDetails
            {
                Title = "Specified resource already exists",
                Detail = exception.Message
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}
