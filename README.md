![Build and Test](https://github.com/dpdsousa/checkout-dotnet-challenge/workflows/Build%20and%20Test/badge.svg?branch=develop)
# Checkout.Com .Net Challenge - Payment Gateway 
## About The Project
This project consists of a Payment Gateway that enables merchants to request payments to a specific bank.

### Built With
* [Microsoft Visual Studio Community 2019](https://visualstudio.microsoft.com/vs/community/)
* [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.301-windows-x64-installer)
* [Docker](https://www.docker.com/products/docker-desktop)

### Running
This project consists of three containers.
* Payment Gateway API
* Bank Mock API
* MongoDB Server

To run these containers it's necessary to have Docker installed and to execute the command below inside the folder **src\CheckoutChallenge.PaymentGateway**.

```
docker-compose up
```

## API
### Get payment by id
Retrieves the payment details with the corresponding Id.

| Endpoint  | Method | Auth required |
| :---: | :---: | :---: |
| `/api/payment/{:id}`  | `GET`  | `Yes` |   

### Get payment by merchant id
Retrieves all the payments that belong to the corresponding merchant.

| Endpoint  | Method | Auth required |
| :---: | :---: | :---: |
| `/api/payment?merchantId=`  | `GET`  | `Yes` |   

### Request payment
Endpoint used by the merchants to request a payment.

| Endpoint  | Method | Auth required |
| :---: | :---: | :---: |
| `/api/payment/`  | `POST`  | `Yes` |   

  **Request sample**
```
{
  "merchantId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "idempotencyId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "amount": 10,
  "currency": "EUR",
  "card": {
    "number": "1234 1234 1234",
    "expiryMonth": 12,
    "expiryYear": 2021,
    "cvv": "123",
    "holderName": "Random name"
  }
}
```
