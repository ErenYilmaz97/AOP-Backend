using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public static class HttpContextResponseExtensions
    {


        public static Task ValidationErrorResponse(this HttpResponse httpResponse, ValidationException exception)
        {
            httpResponse.StatusCode = 400;

            return httpResponse.WriteAsync(new ResponseValidationErrorDetails()
            {
                StatusCode = 400,
                Message = exception.Message,
                ValidationErrors = exception.Errors

            }.ToString());
        }




        public static Task InternalServerErrorResponse(this HttpResponse httpResponse)
        {
            httpResponse.StatusCode = 500;

            return httpResponse.WriteAsync(new ResponseErrorDetails()
            {
                StatusCode = 500,
                Message = "Internal Server Error"

            }.ToString()); ;
        }




        public static Task UnauthorizedResponse(this HttpResponse httpResponse)
        {
            httpResponse.StatusCode = 401;

            return httpResponse.WriteAsync(new ResponseErrorDetails()
            {
                StatusCode = 401,
                Message = "Unauthorized"

            }.ToString()); 
        }




        public static Task ForbiddenResponse(this HttpResponse httpResponse)
        {
            httpResponse.StatusCode = 403;

            return httpResponse.WriteAsync(new ResponseErrorDetails()
            {
                StatusCode = 403,
                Message = "Access Denied"

            }.ToString()); 
        }

    }
}