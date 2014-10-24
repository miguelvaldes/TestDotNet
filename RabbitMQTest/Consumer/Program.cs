using Common;
using ProtoBuf;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.UserName = "prueba";
            factory.Password = "prueba";
            factory.VirtualHost = "/";
            factory.Protocol = Protocols.DefaultProtocol;
            factory.HostName = "192.168.0.175";
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // crea la cola si esta no existe
                    channel.QueueDeclare("hello", true, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("hello", true, consumer);

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        CustomMessageObject msgOut;
                        // esto puede ir dentro del objeto a serializar
                        using (var stream = new MemoryStream(body))
                        {
                            msgOut = Serializer.Deserialize<CustomMessageObject>(stream);
                        }
                        
                        Console.WriteLine(msgOut.Mensaje);
                    }
                }
            }
        }
    }
}
