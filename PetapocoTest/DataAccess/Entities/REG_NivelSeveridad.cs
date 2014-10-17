using DataAccess.Base;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [TableName("REG_NivelSeveridad")]
    [PrimaryKey("IdNivelSeveridad")]
    [ExplicitColumns]
    public partial class REG_NivelSeveridad : BaseConnectionDB.Record<REG_NivelSeveridad>
    {
        [Column]
        public long IdNivelSeveridad { get; set; }
        [Column]
        public string Nombre { get; set; }
        [Column]
        public string Descripcion { get; set; }
    }
}
