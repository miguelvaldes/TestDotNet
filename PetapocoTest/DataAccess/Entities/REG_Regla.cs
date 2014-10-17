using DataAccess.Base;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [TableName("REG_Regla")]
    [PrimaryKey("IdRegla", autoIncrement = false)]
    [ExplicitColumns]
    public partial class REG_Regla : BaseConnectionDB.Record<REG_Regla>
    {
        [Column]
        public long IdRegla { get; set; }
        [Column]
        public long IdNivelSeveridad { get; set; }
        [Column]
        public string Nombre { get; set; }
        [Column]
        public string Descripcion { get; set; }
    }
}
