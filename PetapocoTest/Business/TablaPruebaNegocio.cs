using AutoMapper;
using DataAccess.Dao;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Dto;

namespace Business
{
    public class TablaPruebaNegocio
    {
        public static List<TablaPruebaDto> All() {
            List<TablaPrueba> listadoDB = TablaPruebaDao.All();
            Mapper.CreateMap<TablaPrueba, TablaPruebaDto>();
            List<TablaPruebaDto> listado = Mapper.Map<List<TablaPrueba>, List<TablaPruebaDto>>(listadoDB);
            return listado;
        }

        public static List<TablaPruebaDto> ObtenerTablaPruebaDosNiveles()
        {
            List<TablaPrueba> listadoDB = TablaPruebaDao.ObtenerTablaPruebaDosNiveles();
            Mapper.CreateMap<TablaPrueba, TablaPruebaDto>();
            Mapper.CreateMap<REG_NivelSeveridad, REG_NivelSeveridadDto>();
            List<TablaPruebaDto> listado = Mapper.Map<List<TablaPrueba>, List<TablaPruebaDto>>(listadoDB);
            return listado;
        }

        public static TablaPruebaDto PorId(long id)
        {
            TablaPrueba objDB = TablaPruebaDao.PorId(id);
            Mapper.CreateMap<TablaPrueba, TablaPruebaDto>();
            TablaPruebaDto listado = Mapper.Map<TablaPrueba, TablaPruebaDto>(objDB);
            return listado;
        }

        public static long Insertar(TablaPruebaDto nuevo)
        {
            Mapper.CreateMap<TablaPruebaDto, TablaPrueba>();
            TablaPrueba nuevoB = Mapper.Map<TablaPruebaDto, TablaPrueba>(nuevo);
            return TablaPruebaDao.InsertarConEntidad(nuevoB);
        }

        public static bool InsertarConTransaccion(List<TablaPruebaDto> nuevo)
        {
            Mapper.CreateMap<TablaPruebaDto, TablaPrueba>();
            List<TablaPrueba> nuevoB = Mapper.Map<List<TablaPruebaDto>, List<TablaPrueba>>(nuevo);
            return TablaPruebaDao.InsertarConEntidadTransaccion(nuevoB);
        }

        public static int Actualizar(TablaPruebaDto nuevo)
        {
            Mapper.CreateMap<TablaPruebaDto, TablaPrueba>();
            TablaPrueba nuevoB = Mapper.Map<TablaPruebaDto, TablaPrueba>(nuevo);
            return TablaPruebaDao.ActualizarConEntidad(nuevoB);
        }

        public static TablaPruebaDto ProcedimientoAlmacenado(long id)
        {
            TablaPrueba objDB = TablaPruebaDao.ProcedimientoAlmacenado(id);
            Mapper.CreateMap<TablaPrueba, TablaPruebaDto>();
            TablaPruebaDto listado = Mapper.Map<TablaPrueba, TablaPruebaDto>(objDB);
            return listado;
        }

        public static int EliminarConEntidad(long id)
        {
            return TablaPruebaDao.EliminarConEntidad(id);
        }

        public static int EliminarConSql(long id)
        {
            return TablaPruebaDao.EliminarConSql(id);
        }
    }
}
