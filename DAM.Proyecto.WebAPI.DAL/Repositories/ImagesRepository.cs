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
    public class ImagesRepository : GenericRepository<ImagesTable>, IImagesRepository
    {
        public ImagesRepository(DamDbContext context) : base(context)
        {
            var result = _context.Set<EventoEuskadiTable>().Include(h => h.Images);
        }
    }
}
