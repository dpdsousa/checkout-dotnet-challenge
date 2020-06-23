using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Business.Components
{
    /// <summary>
    /// MerchantBc - Business Component
    /// Class responsible for all the business logic related to Merchant functionalities
    /// </summary>
    public class MerchantBc : IMerchantBc
    {
        private readonly IMerchantRepository _merchantRepository;

        public MerchantBc(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<Merchant> Get(Guid id)
        {
            return await _merchantRepository.Get(id);
        }

        public async Task<Merchant> Add(Merchant merchant)
        {
            var dbMerchant = await _merchantRepository.Get(merchant.Name);
            if(dbMerchant != null)
            {
                throw new BusinessException(
                    BusinessExceptionCodes.MerchantAlreadyExists, 
                    $"Merchant {merchant.Name} already exists"); //TODO: Move this to a resource file.
            }

            merchant.Id = Guid.NewGuid();
            return await _merchantRepository.Add(merchant);
        }
    }
}
