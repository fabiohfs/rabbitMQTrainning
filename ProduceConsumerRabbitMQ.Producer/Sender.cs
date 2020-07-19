using System;
using RabbitMQ.Client;
using System.Text;

namespace ProduceConsumerRabbitMQ.Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                string message = "Primeira mensagem do .Net Core para o RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(string.Empty, "BasicTest", null, body);
                Console.WriteLine("Mensagem {0} enviada", message);
            }

            Console.WriteLine("Pressione enter para sair");
            Console.ReadLine();
        }
    }
}
