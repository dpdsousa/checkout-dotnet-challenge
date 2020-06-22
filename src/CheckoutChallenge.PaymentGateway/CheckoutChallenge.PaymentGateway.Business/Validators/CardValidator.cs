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

            RuleFor(x => x.ExpiryYear)
                .InclusiveBetween(1, 9999).WithMessage("Expiry year must be between {From} and {To}.");

            RuleFor(x => x.ExpiryMonth)
                .InclusiveBetween(1, 12).WithMessage("Expiry month must be between {From} and {To}.");

            RuleFor(x => x).Must(x =>
            {
                var isValid = true;
                var expirationDate = new DateTime(x.ExpiryYear, x.ExpiryMonth, 1).AddMonths(1).AddDays(-1).Date;
                if(DateTime.UtcNow.Date > expirationDate)
                {
                    isValid = false;
                }
                return isValid;
            })
            .When(x => x.ExpiryMonth >= 1 && x.ExpiryMonth <= 12 && x.ExpiryYear > 0 && x.ExpiryYear <= 9999)
            .WithMessage("Card's date has expired.");


        }
    }
}
