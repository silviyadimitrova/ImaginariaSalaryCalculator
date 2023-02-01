using ImaginariaSalaryCalculator.Data;
using ImaginariaSalaryCalculator.Services;
using ImaginariaSalaryCalculator.TaxIncentivesCalculators;
using ImaginariaSalaryCalculator.TaxCalculators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITaxPayerTaxesRepository, TaxPayerTaxesRepository>();
builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddScoped<ITaxCalculatorFactory, TaxCalculatorFactory>();
builder.Services.AddScoped<ITaxIncentivesCalculatorFactory, TaxIncentivesCalculatorFactory>();

// Add memory cache dependencies 
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
