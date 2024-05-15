using MotorcycleRental.Infrastructure.MessageBus;
using RabbitMQ.Client;

namespace MotorcycleRental.API.DependencyInjection
{
    public static class RabbitMqDependencyInjection
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:HostName"],
                UserName= configuration["RabbitMQ:UserName"],
                Password= configuration["RabbitMQ:Password"],
                Port= int.Parse(configuration["RabbitMQ:Port"])
            };

            var connection = connectionFactory.CreateConnection();

            services.AddSingleton(new ProducerConnection(connection));
            services.AddSingleton<IMessageBusClient, RabbitMqClient>();

            return services;
        }
    }
}
