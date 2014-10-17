using DataAccess.Base;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [TableName("TablaPrueba")]
    [PrimaryKey("IdTablaPrueba")]
    [ExplicitColumns]
    public partial class TablaPrueba : BaseConnectionDB.Record<TablaPrueba>
    {
        [Column]
        public long IdTablaPrueba { get; set; }
        [Column]
        public string Descripcion { get; set; }
        [Column]
        public long? IdNivelSeveridad { get; set; }

        public REG_NivelSeveridad NivelSeveridad { get; set; }
    }
}
