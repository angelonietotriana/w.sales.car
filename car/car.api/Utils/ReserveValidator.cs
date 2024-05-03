using FluentValidation;
using w.sale.car.db.Dtos;

namespace w.sale.car.api.Utils
{
    public class ReserveValidator : AbstractValidator<ReserveInDto>
    {
        public ReserveValidator()
        {
            string messageRequiredField = "Information missing for the field {0}";
            string messageUpToZero = "It must be a number greater than zero for the ID attribute.{0}";
            string messageUpToZeroNoId = "It must be a number greater than zero for the attribute {0}";

            RuleFor(x => x)
            .NotNull()
            .WithMessage(string.Format(messageRequiredField, "General structure"));

            RuleFor(x => x.ReserveDate)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Reserve Date"));

            RuleFor(x => x.CollectDate)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Date Collect"));

            RuleFor(x => x.IdCollectLocation)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(string.Format(messageUpToZero, " Location Collect"));


            RuleFor(x => x.IdCar)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(string.Format(messageUpToZero, " Id Car"));

            RuleFor(x => x.BaseCost)
                .NotEmpty()
                .GreaterThan(0)
               .WithMessage(string.Format(messageUpToZeroNoId, " Cost Base"));


        }
    }
}
