using FluentValidation;
using w.sale.car.db.Dtos;


namespace w.sale.car.api.Utils
{
    public class UserValidator : AbstractValidator<UserInDto>
    {
        public UserValidator()
        {
            string messageRequiredField = "Information missing for the field {0}";
          
            RuleFor(x => x)
            .NotNull()
            .WithMessage(string.Format(messageRequiredField, "General structure"));

            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " State"));

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Phone"));

            RuleFor(x => x.DocumentType)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Document Type"));

            RuleFor(x => x.Document)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Document"));

            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Type"));


        }
    }
}
