using CheckoutChallenge.PaymentGateway.Domain.Entities;
using FluentValidation;
using System;

namespace CheckoutChallenge.PaymentGateway.Business.Validators
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage("Card number is mandatory.");

            RuleFor(x => x.Cvv)
                .NotEmpty()
                .WithMessage("Cvv is mandatory.");

            RuleFor(x => x.Cvv)
                .Length(3)
                .When(x => !string.IsNullOrWhiteSpace(x.Cvv))
                .WithMessage("Cvv must have 3 digits.");

            RuleFor(x => x).Must(x =>
            {
                var isValid = true;
                var expirationDate = new DateTime(x.ExpiryYear, x.ExpiryMonth, 1).AddMonths(1).AddDays(-1).Date;
                if(DateTime.UtcNow.Date > expirationDate)
                {
                    isValid = false;
                }
                return isValid;
            }).WithMessage("Card's date has expired");


        }
    }
}
