using CsuNavigatorBackend.ApplicationServices.Dto;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Dto;

public class MapDtoValidator : AbstractValidator<MapDto>
{
    public MapDtoValidator()
    {
        RuleFor(dto => dto.Title)
            .NotEmpty();
        RuleFor(dto => dto.Description)
            .Must(s => s is null || s.Length != 0);
        RuleForEach(dto => dto.Edges)
            .SetValidator(new EdgeDtoValidator());
    }
}