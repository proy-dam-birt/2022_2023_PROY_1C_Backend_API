using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Interfaces.IHelpers
{
    public interface IGenerarDTOsBasica
    {
        IList<QABasicaDTO> GenerarDTOBasico(IEnumerable<MaestroEventosTable> query);
        IList<QABasicaDTO> GenerarDTOEvento(IList<EventoEuskadiTable> query);
        IList<QABasicaDTO> GenerarDTOGastro(IList<GastronomiaEuskadiTable> query);
    }
}
