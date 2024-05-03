using FluentValidation;
using w.sale.car.db.Dtos;


namespace w.sale.car.api.Utils
{
    public class SaleValidator : AbstractValidator<SaleInDto>
    {
        public SaleValidator()
        {
            string messageRequiredField = "Information missing for the field {0}";
          
            RuleFor(x => x)
            .NotNull()
            .WithMessage(string.Format(messageRequiredField, "General structure"));

            RuleFor(x => x.SnReserve)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Id Reserve"));

            RuleFor(x => x.IdCar)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Id Car"));

            RuleFor(x => x.SnReserve)
                     .NotEmpty()
                     .WithMessage(string.Format(messageRequiredField, " Sn Reserve"));

            RuleFor(x => x.IdVendor)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Id Vendor"));

            RuleFor(x => x.IdUser)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Id User"));

            RuleFor(x => x.SaleDate)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Date Sale"));
   
            RuleFor(x => x.TotalSale)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Total Sale"));

            RuleFor(x => x.IdDeliveryLocation)
                .NotEmpty()
                .WithMessage(string.Format(messageRequiredField, " Id Delivery Location"));



        }
    }
}
