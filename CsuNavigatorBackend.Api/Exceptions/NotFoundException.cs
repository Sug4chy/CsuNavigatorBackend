﻿using CsuNavigatorBackend.Domain.Errors;

namespace CsuNavigatorBackend.Api.Exceptions;

public class NotFoundException : ExceptionBase
{
    public override int StatusCode { get; } = StatusCodes.Status404NotFound;

    public static void ThrowIfNull(object? o, Error err)
    {
        if (o is null)
        {
            throw new NotFoundException
            {
                Error = err
            };
        }
    }
}