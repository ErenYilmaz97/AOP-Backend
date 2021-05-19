using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Core.Extensions
{
    public class ResponseValidationErrorDetails : ResponseErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }
}