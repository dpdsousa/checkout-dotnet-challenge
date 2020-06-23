#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CheckoutChallenge.PaymentGateway.WebApi/CheckoutChallenge.PaymentGateway.WebApi.csproj", "CheckoutChallenge.PaymentGateway.WebApi/"]
COPY ["CheckoutChallenge.PaymentGateway.Data.GenericImplementation/CheckoutChallenge.PaymentGateway.Data.GenericImplementation.csproj", "CheckoutChallenge.PaymentGateway.Data.GenericImplementation/"]
COPY ["CheckoutChallenge.PaymentGateway.Data/CheckoutChallenge.PaymentGateway.Data.csproj", "CheckoutChallenge.PaymentGateway.Data/"]
COPY ["CheckoutChallenge.PaymentGateway.Domain/CheckoutChallenge.PaymentGateway.Domain.csproj", "CheckoutChallenge.PaymentGateway.Domain/"]
COPY ["CheckoutChallenge.PaymentGateway.Business/CheckoutChallenge.PaymentGateway.Business.csproj", "CheckoutChallenge.PaymentGateway.Business/"]
RUN dotnet restore "CheckoutChallenge.PaymentGateway.WebApi/CheckoutChallenge.PaymentGateway.WebApi.csproj"
COPY . .
WORKDIR "/src/CheckoutChallenge.PaymentGateway.WebApi"
RUN dotnet build "CheckoutChallenge.PaymentGateway.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheckoutChallenge.PaymentGateway.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheckoutChallenge.PaymentGateway.WebApi.dll"]
