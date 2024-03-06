using CsuNavigatorBackend.ApplicationServices.Dto;
using FluentValidation;

namespace CsuNavigatorBackend.Services.Validators.Dto
{
    public class EdgeDtoValidator : AbstractValidator<EdgeDto>
    {
        public EdgeDtoValidator()
        {
            RuleFor(edge => edge.Point1).NotNull();
            RuleFor(edge => edge.Point2).NotNull();
            RuleFor(edge => edge.Point1.X).NotNull();
            RuleFor(edge => edge.Point1.Y).NotNull();
            RuleFor(edge => edge.Point2.X).NotNull();
            RuleFor(edge => edge.Point2.Y).NotNull();
            RuleFor(edge => edge.Point1.Type).NotNull().NotEmpty();
            RuleFor(edge => edge.Point2.Type).NotNull().NotEmpty();
        }
    }
}
