using CsuNavigatorBackend.Services.Requests.Maps;
using CsuNavigatorBackend.Services.Validators.Dto;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Maps;

public class UpdateMapRequestValidator : AbstractValidator<UpdateMapRequest>
{
    public UpdateMapRequestValidator(MapDtoValidator mapDtoValidator)
    {
        RuleFor(request => request.UpdatedMap)
            .SetValidator(mapDtoValidator);
    }
    
}