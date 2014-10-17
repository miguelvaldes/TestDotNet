using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class TablaPruebaDao
    {
        public static List<TablaPrueba> All()
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                return db.Query<TablaPrueba>("select * from TablaPrueba").ToList();
            }
        }

        public static List<TablaPrueba> ObtenerTablaPruebaDosNiveles()
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                var sql = @"select 
                                t.*, n.* 
                            from TablaPrueba t 
                            inner join REG_NivelSeveridad n ON t.IdNivelSeveridad = n.IdNivelSeveridad";
                return db.Query<TablaPrueba, REG_NivelSeveridad>(sql).ToList();
            }
        }

        public static TablaPrueba PorId(long id)
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                return db.SingleOrDefault<TablaPrueba>("select * from TablaPrueba where IdTablaPrueba = @a", new { a = id });
            }
        }

        public static long InsertarConEntidad(TablaPrueba a)
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                var idEntidad = db.Insert(a);
                return (long)idEntidad;
            }
        }

        public static bool InsertarConEntidadTransaccion(List<TablaPrueba> lista)
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                try
                {
                    var scope = db.GetTransaction();
                    foreach (TablaPrueba a in lista)
                    {
                        var idEntidad = db.Insert(a);
                    }
                    scope.Complete(); // si no llega a complete no hace commit, por ello no es necesario hacer rollback
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static int ActualizarConEntidad(TablaPrueba actual)
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                TablaPrueba a = db.SingleOrDefault<TablaPrueba>("select * from TablaPrueba where IdTablaPrueba = @a", new { a = 13 });
                // lo siguiente también se puede hacer con el automapper, pasando como parametro al entidad de la BD y la actual
                a.IdNivelSeveridad = actual.IdNivelSeveridad;
                a.Descripcion = actual.Descripcion;
                return db.Update(a); // retorna 1 si es exitoso

                // también se puede hacer update con sql
                // db.Update<TablaPrueba>("SET Descripcion = @a WHERE IdTablaPrueba = @b", new { a= actual.IdNivelSeveridad, b=actual.IdTablaPrueba });
            }
        }

        public static TablaPrueba ProcedimientoAlmacenado(long id)
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                TablaPrueba tabla = db.SingleOrDefault<TablaPrueba>(";EXEC USP_GetTablaPruebaPorId @@id = @a", new { a = id });
                //TablaPrueba2 tabla2 = db.Fetch<TablaPrueba2>(";EXEC USP_GetTablaPruebaPorId @@id = @a", new { a = 2 }).FirstOrDefault();
                return tabla;
            }
        }

        public static int EliminarConEntidad(long id)
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                TablaPrueba a = db.SingleOrDefault<TablaPrueba>("select * from TablaPrueba where IdTablaPrueba = @a", new { a = id });
                return db.Delete(a); // retorna 1 si es exitoso
            }
        }

        public static int EliminarConSql(long id)
        {
            using (PetaPoco.Database db = new PetaPoco.Database(Base.Model.BASE))
            {
                return db.Delete<TablaPrueba>("WHERE IdTablaPrueba=@a", new { a = id });
            }
        }
    }
}
