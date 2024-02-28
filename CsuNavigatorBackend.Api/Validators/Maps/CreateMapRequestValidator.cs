using CsuNavigatorBackend.Api.Requests.Maps;
using FluentValidation;

namespace CsuNavigatorBackend.Api.Validators.Maps
{
    public class CreateMapRequestValidator : AbstractValidator<CreateMapRequest>
    {
        public CreateMapRequestValidator() 
        {
            RuleFor(request => request.Map).NotNull();
            RuleFor(request => request.Map.Title).NotNull().NotEmpty();
            RuleFor(request => request.Map.Edges).NotNull();
            RuleForEach(request => request.Map.Edges).SetValidator(new EdgeDtoValidator());

            RuleFor(request => request.OrganizationName)
                .NotNull()
                .NotEmpty();
        }

    }
}
