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
    public class REG_ReglaNegocio
    {
        public static List<REG_ReglaDto> AllPaged(int page, int itemsPerPage)
        {
            List<REG_Regla> listadoDB = REG_ReglaDao.AllPaged(page, itemsPerPage);
            Mapper.CreateMap<REG_Regla, REG_ReglaDto>();
            List<REG_ReglaDto> listado = Mapper.Map<List<REG_Regla>, List<REG_ReglaDto>>(listadoDB);
            return listado;
        }
    }
}
