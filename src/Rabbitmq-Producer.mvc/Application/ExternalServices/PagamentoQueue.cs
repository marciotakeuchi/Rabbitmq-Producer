using Rabbitmq_Producer.mvc.WebUI.Models;
using RabbitMQ.Client;
using System.Text.Json;
using Rabbitmq_Producer.mvc.Domain.Entities;
using System.Text;

namespace Rabbitmq_Producer.mvc.Application.ExternalServices
{
    public class PagamentoQueue : IPagamentoQueue
    {

        public bool ConfirmarPagamento(PagamentoCreateViewModel pagamentoCreateViewModel)
        {
            var queueName = "paymentConfirmation";

            return EnviarParaFila(pagamentoCreateViewModel, queueName);
        }

        private static bool EnviarParaFila(PagamentoCreateViewModel pagamentoCreateViewModel, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    try
                    {
                        channel.QueueDeclare(
                            queue: queueName,
                            durable: true,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null
                        );

                        string message = JsonSerializer.Serialize<PagamentoCreateViewModel>(pagamentoCreateViewModel);

                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(
                            exchange: string.Empty,
                            routingKey: queueName,
                            basicProperties: null,
                            body: body
                            );

                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }

                }
            }
        }
    }
}
