using System;

namespace CheckoutChallenge.PaymentGateway.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public string ExceptionCode { get; }

        public BusinessException(string exceptionCode, string message) : base(message)
        {
            ExceptionCode = exceptionCode;
        }
    }
}
