using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
             
                channel.QueueDeclare(queue: "DevJJGR", durable:false, exclusive: false,autoDelete: false, arguments: null);
                Console.WriteLine("Esperando...");
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.Write($"[x] Mensaje recibido {message}{Environment.NewLine}");

                
                };
                channel.BasicConsume(queue: "DevJJGR", autoAck: true, consumer: consumer);
                Console.WriteLine("press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}