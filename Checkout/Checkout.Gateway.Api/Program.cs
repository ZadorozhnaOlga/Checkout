using Checkout.Db;
using Checkout.Db.Repository;
using Checkout.Gateway.Api.Interfaces;
using Checkout.Gateway.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CheckoutDbContext>(options =>
options.UseSqlServer("Server=LAPTOP-MNNVHMJQ\\SQLEXPRESS;Database=Checkout;Trusted_Connection=True;TrustServerCertificate=True",
x => x.MigrationsAssembly("Checkout.Db")));

builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICardDetailsRepository, CardDetailsRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
