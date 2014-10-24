using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using Common;
using ProtoBuf;
using System.IO;

namespace Producer
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

                    var properties = channel.CreateBasicProperties();
                    properties.SetPersistent(true);

                    CustomMessageObject objeto = new CustomMessageObject() { Mensaje = "mensaje de prueba" };

                    // esto puede ir dentro de la case a enviar, y en lugar de objeto va this
                    byte[] msgOut;
                    using (var stream = new MemoryStream())
                    {
                        Serializer.Serialize(stream, objeto);
                        msgOut = stream.ToArray();
                    }

                    channel.BasicPublish("", "hello", null, msgOut);
                }
            }
        }
    }
}
