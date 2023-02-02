using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;

namespace DAM.Proyecto.WebAPI.DAL.Repositories
{
    public class FechasEventosRepository : GenericRepository<FechasEventosTable>, IFechasEventosRepository
    {
        public FechasEventosRepository(DamDbContext context) : base(context)
        {

        }
    }
}
