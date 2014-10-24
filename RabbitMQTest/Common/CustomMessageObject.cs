using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [ProtoContract]
    public class CustomMessageObject
    {
        [ProtoMember(1)]
        public string Mensaje { get; set; } 
    }
}
