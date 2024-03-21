﻿using CsuNavigatorBackend.ApplicationServices.Dto;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Dto;

public class MapDtoValidator : AbstractValidator<MapDto>
{
    public MapDtoValidator(EdgeDtoValidator edgeDtoValidator)
    {
        RuleFor(dto => dto.Id)
            .Null();
        RuleFor(dto => dto.Title)
            .NotEmpty();
        RuleFor(dto => dto.Description)
            .Must(s => s is null || s.Length != 0);
        RuleForEach(dto => dto.Edges)
            .SetValidator(edgeDtoValidator);
    }
}