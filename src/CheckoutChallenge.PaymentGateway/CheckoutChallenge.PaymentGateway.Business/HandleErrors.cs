using CheckoutChallenge.PaymentGateway.Domain.Exceptions;
using FluentValidation.Results;

namespace CheckoutChallenge.PaymentGateway.Business
{
    public static class HandleErrors
    {
        public static void HandleValidatorResult(ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                var validationException = new ValidationException();
                foreach (var error in validationResult.Errors)
                {
                    validationException.AddValidationError(error.PropertyName, error.ErrorMessage);
                }
                throw validationException;
            }
        }
    }
}
