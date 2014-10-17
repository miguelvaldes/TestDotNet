using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Dto
{
    [DataContract]
    public class TablaPruebaDto
    {
        [DataMember]
        public long IdTablaPrueba { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public long? IdNivelSeveridad { get; set; }
        [DataMember]
        public REG_NivelSeveridadDto NivelSeveridad { get; set; }
    }
}
