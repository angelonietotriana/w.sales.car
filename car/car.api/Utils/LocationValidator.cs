using FluentValidation;
using w.sale.car.db.Dtos;


namespace w.sale.car.api.Utils
{
    public class LocationValidator : AbstractValidator<LocationInDto>
    {
        public LocationValidator()
        {
            string mensajeDatoObligatorio = "Information missing for the field {0}";

            RuleFor(x => x)
            .NotNull()
            .WithMessage(string.Format(mensajeDatoObligatorio, "General structure"));

            RuleFor(x => x.Zone)
                .NotEmpty()
                .WithMessage(string.Format(mensajeDatoObligatorio, " Zone"));

            RuleFor(x => x.Available)
                .NotEmpty()
                .WithMessage(string.Format(mensajeDatoObligatorio, " Available"));

            RuleFor(x => x.Locality)
             .NotEmpty()
             .WithMessage(string.Format(mensajeDatoObligatorio, " Locality"));



        }
    }
}
