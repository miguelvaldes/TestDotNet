using Business;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using Transport.Dto;


namespace PetapocoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ObtenerTablaPruebaUnNivel();
            //ObtenerTablaPruebaDosNiveles();
            //ObtenerUnaTabla();
            //ObtenerListadoPorPagina();
            //InsertarConEntidad();
            //InsertarConEntidadTransaccion();
            //ActualizarConEntidad();
            //ProcedimientoAlmacenado();
            //EliminarConEntidad();
            //EliminarConSql();
        }

        public static void ObtenerTablaPruebaUnNivel()
        {
            List<TablaPruebaDto> lista = TablaPruebaNegocio.All();
        }

        public static void ObtenerTablaPruebaDosNiveles()
        {
            List<TablaPruebaDto> lista = TablaPruebaNegocio.ObtenerTablaPruebaDosNiveles();
        }

        public static void ObtenerUnaTabla()
        {
            TablaPruebaDto obj = TablaPruebaNegocio.PorId(1);
        }

        public static void ObtenerListadoPorPagina()
        {
            List<REG_ReglaDto> lista = REG_ReglaNegocio.AllPaged(2, 5);
        }
        
        private static void InsertarConEntidad()
        {
            var a = new TablaPruebaDto() { Descripcion = "tabla prueba 3", IdNivelSeveridad = 3 };
            long id = TablaPruebaNegocio.Insertar(a);
        }

        private static void InsertarConEntidadTransaccion()
        {
            List<TablaPruebaDto> lista = new List<TablaPruebaDto>();
            lista.Add(new TablaPruebaDto() { Descripcion = "tabla prueba 4", IdNivelSeveridad = 2 });
            lista.Add(new TablaPruebaDto() { Descripcion = "tabla prueba 5", IdNivelSeveridad = 1 });
            bool ok = TablaPruebaNegocio.InsertarConTransaccion(lista);
        }

        
        private static void ActualizarConEntidad()
        {
            TablaPruebaDto a = TablaPruebaNegocio.PorId(13);
            a.IdNivelSeveridad = 2;
            a.Descripcion = "prueba update";
            int res = TablaPruebaNegocio.Actualizar(a);
        }

        public static void ProcedimientoAlmacenado()
        {
            TablaPruebaDto tabla = TablaPruebaNegocio.ProcedimientoAlmacenado(13);
        }

        private static void EliminarConEntidad()
        {
            int res = TablaPruebaNegocio.EliminarConEntidad(14);
        }

        private static void EliminarConSql()
        {
            int res = TablaPruebaNegocio.EliminarConSql(15);
        }
    }
}
