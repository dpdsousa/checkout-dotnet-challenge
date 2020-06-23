![Build and Test](https://github.com/dpdsousa/checkout-dotnet-challenge/workflows/Build%20and%20Test/badge.svg?branch=develop)
# Checkout.Com .Net Challenge - Payment Gateway 
## About The Project
This is a Payment Gateway that enables merchants to request payments to a specific bank.

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

## API - Payments
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

## API - Merchants
### Get merchant by id
Retrieves the merchant with the corresponding Id.

| Endpoint  | Method | Auth required |
| :---: | :---: | :---: |
| `/api/merchant/{:id}`  | `GET`  | `Yes` |   

### Create merchant
Endpoint used to create a new merchant.

| Endpoint  | Method | Auth required |
| :---: | :---: | :---: |
| `/api/merchant/`  | `POST`  | `Yes` |   


