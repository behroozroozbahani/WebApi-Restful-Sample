using Microsoft.EntityFrameworkCore;
using Task.Application.Interfaces.Contexts;
using Task.Application.Interfaces.FacadePatterns;
using Task.Application.Services.Customers.FacadePattern;
using Task.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-----------------------------------------------------------------------------------------------------------

//Connection String
string connectionString = @"Server= .\SQL2022; Initial Catalog= TaskDB; Integrated Security= True; TrustServerCertificate= True";
builder.Services
       .AddEntityFrameworkSqlServer()
       .AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString));

//DataBase Context Service
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();

//Customer Services
builder.Services.AddScoped<ICustomerFacade, CustomerFacade>();

//-----------------------------------------------------------------------------------------------------------

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