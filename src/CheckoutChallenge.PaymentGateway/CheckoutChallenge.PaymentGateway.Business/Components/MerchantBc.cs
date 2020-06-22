using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using CheckoutChallenge.PaymentGateway.Domain.Exceptions;
using System;

namespace CheckoutChallenge.PaymentGateway.Business.Components
{
    public class MerchantBc : IMerchantBc
    {
        private readonly IMerchantRepository _merchantRepository;

        public MerchantBc(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public Merchant Get(Guid id)
        {
            return _merchantRepository.Get(id);
        }

        public Merchant Add(Merchant merchant)
        {
            var dbMerchant = _merchantRepository.Get(merchant.Name);
            if(dbMerchant != null)
            {
                throw new BusinessException(
                    BusinessExceptionCodes.MerchantAlreadyExists, 
                    $"Merchant {merchant.Name} already exists"); //TODO: Move this to a resource file.
            }

            merchant.Id = Guid.NewGuid();
            return _merchantRepository.Add(merchant);
        }
    }
}
