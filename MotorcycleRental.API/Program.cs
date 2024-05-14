using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorcycleRental.API.DependencyInjection;
using MotorcycleRental.API.Filters;
using MotorcycleRental.API.Middleware;
using MotorcycleRental.Application.Commands.CreateMotorcycle;
using MotorcycleRental.Application.Validators;
using MotorcycleRental.Infrastructure.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddLoginDependencyInjection(builder.Configuration);
builder.Host.UseSerilog();

builder.Services.AddMessageBus();

builder.Services.AddDbContext<MotorcycleRentalDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MotorcycleRental")));

builder.Services.AddRepositoriesDependencyInjection();

builder.Services.AddFluentValidationDependencyInjection();

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

builder.Services.AddMediatR(typeof(CreateMotorcycleCommand).Assembly);

builder.Services.AddSwaggerDependencyInjection(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddRouting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "MotorcycleRental V1");
    });

    app.MigrateDatabase();

}

app.UseHttpsRedirection();

app.UseRouting();

//adiciona o middleware de tratamento de erros
app.ConfigureExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
