﻿using CheckoutChallenge.PaymentGateway.Data.Context;
using CheckoutChallenge.PaymentGateway.Data.MongoDb.Repositories.Core;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace CheckoutChallenge.PaymentGateway.Data.MongoDb.Repositories
{
    public class MerchantRepository : CoreRepository<Merchant, Guid>, IMerchantRepository
    {
        public MerchantRepository(IMongoContext mongoContext) : base(mongoContext)
        {
        }

        public async Task<Merchant> Get(string name)
        {
            return await _dbCollection.Find(x => x.Name == name).FirstOrDefaultAsync();
        }
    }
}
