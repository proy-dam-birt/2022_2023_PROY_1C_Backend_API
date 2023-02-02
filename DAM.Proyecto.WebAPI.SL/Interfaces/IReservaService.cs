using DAM.Proyecto.SL.Services;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Interfaces
{
    public interface IReservaService
    {

       public ExpandoObject CreateReserva(int userId, int maestroID, int plazasReservadas, DateTime fecha);
       public List<ExpandoObject> getReservas(int id);
       public List<ExpandoObject> getAvailable();

    }
       
}
