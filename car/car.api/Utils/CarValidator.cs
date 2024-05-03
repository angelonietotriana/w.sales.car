using FluentValidation;
using w.sale.car.db.Dtos;


namespace w.sale.car.api.Utils
{
    public class CarValidator : AbstractValidator<CarInDto>
    {
        public CarValidator()
        {
            string messageRequiredField = "Information missing for the field {0}";
             string messageUpToZeroNoId = "It must be a number greater than zero for the attribute {0}";

            RuleFor(x => x)
            .NotNull()
            .WithMessage(string.Format(messageRequiredField, "General structure"));

            RuleFor(x => x.Available)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Available"));

            RuleFor(x => x.Make)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Brand"));

            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Type Car"));

            RuleFor(x => x.Capacity)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(string.Format(messageUpToZeroNoId, " Passanger capacity"));

            RuleFor(x => x.Model)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(string.Format(messageUpToZeroNoId, " Model Car"));

            RuleFor(x => x.Mileage)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(string.Format(messageUpToZeroNoId, " Mileage"));

            RuleFor(x => x.Cost)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(string.Format(messageUpToZeroNoId, " Cost"));

        }
    }
}
