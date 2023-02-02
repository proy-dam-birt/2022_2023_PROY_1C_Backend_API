using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Interfaces
{
    public interface IActividadQueryIDService
    {      
        Task<QADetalleDTO> GetActividadByID(int id);
    }
}
