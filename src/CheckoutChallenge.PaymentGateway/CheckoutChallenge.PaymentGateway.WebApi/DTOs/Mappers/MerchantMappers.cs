using CheckoutChallenge.PaymentGateway.Domain.Entities;

namespace CheckoutChallenge.PaymentGateway.WebApi.DTOs.Mappers
{
    public static class MerchantMappers
    {
        public static Merchant Map(CreateMerchantDto merchant)
        {
            return new Merchant
            {
                Name = merchant.Name
            };
        }

        public static MerchantDto Map(Merchant merchant)
        {
            return new MerchantDto
            {
                Id = merchant.Id,
                Name = merchant.Name
            };
        }
    }
}
