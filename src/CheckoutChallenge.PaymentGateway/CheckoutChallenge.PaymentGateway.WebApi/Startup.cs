using CheckoutChallenge.PaymentGateway.Business.Interfaces;
using CheckoutChallenge.PaymentGateway.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using CheckoutChallenge.PaymentGateway.Data;
using CheckoutChallenge.PaymentGateway.Data.MongoDb;
using CheckoutChallenge.PaymentGateway.Data.Context;
using CheckoutChallenge.PaymentGateway.Data.MongoDb.Context;
using CheckoutChallenge.PaymentGateway.Data.MongoDb.Repositories;
using CheckoutChallenge.PaymentGateway.Business.Components;
using CheckoutChallenge.PaymentGateway.WebApi.Core;
using CheckoutChallenge.PaymentGateway.Domain.ApiClients;
using System;

namespace CheckoutChallenge.PaymentGateway.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<MongoSettings>(Configuration.GetSection("MongoDbSettings"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = typeof(Startup).Namespace, Version = "v1" });
            });

            services.AddSingleton<IDatabaseSettings>(serviceProvider => 
                serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value);

            services.AddHttpClient<IBankApiClient, BankApiClient>(client =>
            {
                var baseUrl = Configuration["BankServiceApiSettings:BaseUrl"];
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddTransient<IMerchantBc, MerchantBc>();
            services.AddTransient<IPaymentBc, PaymentBc>();

            services.AddTransient<IMongoContext, MongoContext>();
            services.AddTransient<IMerchantRepository, MerchantRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseAuthorization();

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
