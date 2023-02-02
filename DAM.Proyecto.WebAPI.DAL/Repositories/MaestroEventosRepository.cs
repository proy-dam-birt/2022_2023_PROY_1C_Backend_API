using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.DAL.Repositories
{
    public class MaestroEventosRepository : GenericRepository<MaestroEventosTable>, IMaestroEventosRepository
    {
        public MaestroEventosRepository(DamDbContext context) : base(context)
        {
        }
    }
}
