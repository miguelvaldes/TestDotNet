using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class REG_ReglaDao
    {
        public static List<REG_Regla> AllPaged(int page, int itemsPerPage)
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                return db.Page<REG_Regla>(page, itemsPerPage, "select * from REG_Regla", "algo").Items;
            }
        }
    }
}
