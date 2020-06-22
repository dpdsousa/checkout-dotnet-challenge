﻿using CheckoutChallenge.PaymentGateway.Data.Repositories.Core;
using CheckoutChallenge.PaymentGateway.Domain.Entities;
using System;

namespace CheckoutChallenge.PaymentGateway.Data.Repositories
{
    public interface IPaymentRepository : ICoreRepository<Payment, Guid>
    {
    }
}