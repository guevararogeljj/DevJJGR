using System;
using System.Text;
using DevJJGR.Application.Common.Interfaces;
using RabbitMQ.Client;

namespace DevJJGR.Infrastructure.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "DevJJGR", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "", routingKey: "DevJJGR", basicProperties: null, body: body);
                }
            }
        }
    }
}

