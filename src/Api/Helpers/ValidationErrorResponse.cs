using FluentValidation;
using System.Collections.Generic;

namespace Api.Helpers
{
    public partial class Error
    {
        public string Message { get; set; }
    }

    public class ValidationErrorResponse
    {
        public int StatusCode { get; set; }
        public List<Error> Errors { get; set; } = new List<Error>();

        public ValidationErrorResponse(int statusCode, ValidationException e)
        {
            StatusCode = statusCode;

            foreach (var error in e.Errors)
            {
                Errors.Add(new Error { Message = error.ErrorMessage });
            }
        }
    }
}
