using CsuNavigatorBackend.Domain.Errors;
using FluentValidation.Results;

namespace CsuNavigatorBackend.Web.Exceptions;

public class BadRequestException : ExceptionBase
{
    public override int StatusCode => StatusCodes.Status400BadRequest;
    
    public static void ThrowByValidationResult(ValidationResult result)
    {
        if (!result.IsValid)
        {
            var error = result.Errors[0];
            throw new BadRequestException
            {
                Error = new Error(error.ErrorCode, error.ErrorMessage)
            };
        }
    }
}