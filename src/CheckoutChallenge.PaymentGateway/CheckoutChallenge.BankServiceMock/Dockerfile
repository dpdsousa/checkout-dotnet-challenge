#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CheckoutChallenge.BankServiceMock/CheckoutChallenge.BankServiceMock.csproj", "CheckoutChallenge.BankServiceMock/"]
RUN dotnet restore "CheckoutChallenge.BankServiceMock/CheckoutChallenge.BankServiceMock.csproj"
COPY . .
WORKDIR "/src/CheckoutChallenge.BankServiceMock"
RUN dotnet build "CheckoutChallenge.BankServiceMock.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheckoutChallenge.BankServiceMock.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheckoutChallenge.BankServiceMock.dll"]
