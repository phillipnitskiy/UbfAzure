using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Business.Interfacies.Exceptions;

namespace WebApi.Filters
{
    public class CustomExceptionFilter :ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ItemNotFoundException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            if (actionExecutedContext.Exception is AccessDeniedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            if (actionExecutedContext.Exception is XmlValidationException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }

            base.OnException(actionExecutedContext);
        }
    }
}