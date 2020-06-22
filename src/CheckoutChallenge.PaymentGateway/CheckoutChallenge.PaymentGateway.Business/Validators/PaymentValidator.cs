using CheckoutChallenge.PaymentGateway.Domain.Entities;
using FluentValidation;

namespace CheckoutChallenge.PaymentGateway.Business.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Currency)
                .Length(3)
                .WithMessage("Currency code is invalid. It should have {MaxLength} characters.");

            RuleFor(x => x.Card)
                .SetValidator(new CardValidator());
        }
    }
}
