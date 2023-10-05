using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteB3.RabbitMq
{
    public class Publisher
    {
        public void SendMessage(string message, string queue, string hostName = "")
        {
            var factory = new ConnectionFactory()
            {
                HostName = string.IsNullOrWhiteSpace(hostName) ? "localhost" : hostName
            };

            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: queue,
                    basicProperties: null,
                    body: body);
            }
        }
    }
}
