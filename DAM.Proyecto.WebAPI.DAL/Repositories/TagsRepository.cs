using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.DAL.Repositories
{
    public class TagsRepository : GenericRepository<TagsTable>, ITagsRepository
    {
        public TagsRepository(DamDbContext context) : base(context)
        {
        }
    }
}
