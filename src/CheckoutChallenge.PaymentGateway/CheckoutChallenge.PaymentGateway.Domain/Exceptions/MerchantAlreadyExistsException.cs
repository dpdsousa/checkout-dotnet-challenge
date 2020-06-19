using System;

namespace CheckoutChallenge.PaymentGateway.Domain.Exceptions
{
    public class MerchantAlreadyExistsException : Exception
    {
        public MerchantAlreadyExistsException(string name)
            : base($"Merchant {name} already exists.")
        {
        }
    }
}
