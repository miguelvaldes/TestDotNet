using Apache.NMS;
using Apache.NMS.Util;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnectionFactory factory = new NMSConnectionFactory("tcp://192.168.0.175:61616");
            IConnection conn = factory.CreateConnection();
            conn.Start();
            ISession session = conn.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination queue = SessionUtil.GetDestination(session, "ExampleQueue");
            IMessageConsumer cons = session.CreateConsumer(queue);
            cons.Listener += new MessageListener(MessageListener);
            Console.ReadLine();
        }

        public static void MessageListener(IMessage msg)
        {
            IObjectMessage objMessage = msg as IObjectMessage;
            OperatorRequestObject oro = (OperatorRequestObject)objMessage.Body;
            Console.WriteLine(oro.Shortcode);
        }
    }
}
