using System.Collections.Generic;

namespace CheckoutChallenge.PaymentGateway.Domain.Exceptions
{
    public class ValidationError
    {
        public ValidationError(string propertyName, IEnumerable<string> errorMessages)
        {
            PropertyName = propertyName;
            ErrorMessages = errorMessages;
        }

        public IEnumerable<string> ErrorMessages { get; }
        public string PropertyName { get; }
    }
}
