using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Core.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

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
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";

            
            if (e.GetType() == typeof(ValidationException))
            {
                //VALIDATIONEXCEPTION OLARAK CAST EDİP YOLLUYORUZ
                return httpContext.Response.ValidationErrorResponse((ValidationException)e);
            }



            if (e.GetType() == typeof(AuthenticationException))
            {
                return httpContext.Response.UnauthorizedResponse();
            }



            if (e.GetType() == typeof(AuthorizationException))
            {
                return httpContext.Response.ForbiddenResponse();
            }


            //DİĞER EXCEPTION DURUMLARI
            return httpContext.Response.InternalServerErrorResponse();
        }
    }
}