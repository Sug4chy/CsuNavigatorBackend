using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Dto;

public class PointDtoValidator : AbstractValidator<PointDto>
{
    public PointDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .Null();
        RuleFor(dto => dto.Type)
            .NotEmpty()
            .Must(s => Enum.TryParse<MarkerType>(s, out _));
        RuleFor(dto => dto.Description)
            .Must(s => s is null || s.Length != 0);
    }
}