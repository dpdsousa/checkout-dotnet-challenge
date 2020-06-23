using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutChallenge.PaymentGateway.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base(string.Empty) { }

        public ICollection<ValidationError> Errors { get; set; } = new HashSet<ValidationError>();

        public void AddValidationError(string propertyName, string errorMessage)
        {
            Errors.Add(new ValidationError(propertyName, new[] { errorMessage }));
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var validationError in Errors)
            {
                stringBuilder.AppendLine($"{validationError.PropertyName}: {string.Join(", ", validationError.ErrorMessages)}");
            }
            return stringBuilder.ToString();
        }
    }
}
