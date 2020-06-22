using System.Collections.Generic;

namespace CheckoutChallenge.PaymentGateway.WebApi.Core
{
    public class BadRequestMessage
    {
        public class PropertyError
        {
            private string _propertyName;
            public string PropertyName
            {
                get { return _propertyName; }
                set { _propertyName = value?.ToLower() ?? string.Empty; }
            }
            public IEnumerable<string> Errors { get; set; }
        }
        public IEnumerable<PropertyError> Errors { get; set; }
    }
}
