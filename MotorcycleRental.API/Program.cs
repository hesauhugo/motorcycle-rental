using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MotorcycleRental.Application.Commands.CreateMotorcycle;
using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Infrastructure.Persistence;
using MotorcycleRental.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddDbContext<MotorcycleRentalDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MotorcycleRental")));

builder.Services.AddScoped(typeof(IMotorcycleRepository), typeof(MotorcycleRepository));

builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreateMotorcycleCommand).Assembly);

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

}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
