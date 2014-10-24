using Apache.NMS;
using Apache.NMS.Util;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatorRequestObject orb = new OperatorRequestObject();
            orb.Shortcode = "mensaje de prueba 2";

            IConnectionFactory factory = new NMSConnectionFactory("tcp://192.168.0.175:61616");
            IConnection conn = factory.CreateConnection();
            conn = factory.CreateConnection();
            conn.Start();
            ISession session = conn.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination queue = SessionUtil.GetDestination(session, "ExampleQueue");
            IMessageProducer prod = session.CreateProducer(queue);
            IObjectMessage objMessage = session.CreateObjectMessage(orb);

            prod.Send(objMessage);
            session.Close();
            conn.Stop();
        }
    }
}
