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
    public class GastronomiaEuskadiRepository : GenericRepository<GastronomiaEuskadiTable>, IGastronomiaEuskadiRepository
    {
        public GastronomiaEuskadiRepository(DamDbContext context) : base(context)
        {
        }
        public GastronomiaEuskadiTable GetById(int? gastroId)
        {
            if (_context.Set<GastronomiaEuskadiTable>().Find(gastroId) == null) throw new Exception($"No existe entidad con el identificador {gastroId}");
            return _context.Set<GastronomiaEuskadiTable>().Find(gastroId);

        }
    }
}
