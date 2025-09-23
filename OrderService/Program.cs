using Microsoft.EntityFrameworkCore;
using OrderService.Common_Repository;
using OrderService.DataBase_Context;
using OrderService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Database Context
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository
builder.Services.AddTransient(typeof(CommonRepoInterfac<,>), typeof(CommonRepoImplementation<,>));

// Set hosting URL
builder.WebHost.UseUrls("https://localhost:5003");

// CORS for Angular dev server
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// ✅ Configure HttpClient for UserClient to ignore SSL locally
builder.Services.AddHttpClient<UserClient>()
    .ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        });

builder.Services.AddHttpClient<NotificationClient>()
    .ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        }); 


var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularClient"); // Enable CORS

app.UseAuthorization();

app.MapControllers();

app.Run();
