using CsuNavigatorBackend.Services.Requests.Edges;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Edges;

public class CreateEdgeRequestValidator : AbstractValidator<CreateEdgeRequest>
{
    public CreateEdgeRequestValidator()
    {
        RuleFor(request => request.Point1Id)
            .NotEqual(Guid.Empty);
        RuleFor(request => request.Point2Id)
            .NotEqual(Guid.Empty);
    }
}