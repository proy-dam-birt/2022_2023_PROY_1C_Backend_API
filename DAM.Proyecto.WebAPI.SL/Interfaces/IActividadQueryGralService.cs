using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Interfaces
{
    public interface IActividadQueryGralService
    {
        IList<QABasicaDTO> GetActividades(QueryInput filtros);

        //IList<QABasicaDTO> GetActividadByFiltro(QueryInput filtros);
    }
}
