using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.DAL.Repositories
{
    public class EventoEuskadiRepository : GenericRepository<EventoEuskadiTable>, IEventoEuskadiRepository
    {
        public EventoEuskadiRepository(DamDbContext context) : base(context)
        {
            var result = _context.Set<EventsTable>().Include(h => h.Eventos);
        }
        public EventoEuskadiTable GetById(int? eventoId) 
        {
            if (_context.Set<EventoEuskadiTable>().Find(eventoId) == null) throw new Exception($"No existe entidad con el identificador {eventoId}");
            return _context.Set<EventoEuskadiTable>().Find(eventoId);
          
        }
    }
    
}
