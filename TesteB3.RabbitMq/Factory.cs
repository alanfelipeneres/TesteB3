using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteB3.RabbitMq
{
    internal class Factory
    {
        public Factory(string hostName = null) 
        {
            var factory = new ConnectionFactory()
            {
                HostName = string.IsNullOrWhiteSpace(hostName) ? "localhost" : hostName
            };

            using (var connection = factory.CreateConnection())

            using(var channel = connection.CreateModel())
            {

            }
        }

        public void sendMessage(string message)
        {

        }
    }
}
