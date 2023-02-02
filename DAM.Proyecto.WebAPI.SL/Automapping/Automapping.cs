using AutoMapper;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Automapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // mapeo en ambos sentidos, ignora si fantan propiedades
            CreateMap<UserTable, UserDTO>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
