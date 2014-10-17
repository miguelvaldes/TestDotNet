using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Dto
{
    [DataContract]
    public class REG_ReglaDto
    {
        [DataMember]
        public long IdRegla { get; set; }
        [DataMember]
        public long IdNivelSeveridad { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
