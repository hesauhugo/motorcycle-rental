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
                HostName = configuration["RabbitConnection"]
            };

            var connection = connectionFactory.CreateConnection("motorcycle-producer");

            services.AddSingleton(new ProducerConnection(connection));
            services.AddSingleton<IMessageBusClient, RabbitMqClient>();

            return services;
        }
    }
}
