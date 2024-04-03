using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using MerchantTest.Api;
using MerchantTest.Api.Extensions;
using MerchantTest.Applicatiýon.Hubs;
using MerchantTest.Domain.Entities;
using MerchantTest.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

// MediatR için servisleri ekleyin

// Baþka servislerin eklemleri buraya gelebilir...

// Hub'ýn context'ini ekleyin
var assemblies = new Assembly[]
{
    typeof(Program).Assembly,
    typeof(PostgreSqlContext).Assembly,
    typeof(Merchant).Assembly,
    typeof(MerchantAddedPaymentMethodHandler).Assembly
};

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var connection = builder.Configuration["ConnectionStrings:PostgreSqlConnection"];
builder.Services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(connection));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DependencyResolver()));
builder.Host.UseSerilog();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("Cache"));

var app = builder.Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Logger(lg1 => lg1
        .WriteTo.MongoDB(builder.Configuration["ConnectionStrings:MongoDB"], collectionName: DateTime.Now.ToString("yyyy_MM_dd"))
    )
    .Enrich.FromLogContext()
    .CreateLogger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseAuthorization();

app.MapControllers();

app.MapHub<MerchantHub>("/merchantHub");


app.Run();
