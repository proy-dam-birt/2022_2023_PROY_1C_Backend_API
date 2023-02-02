using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.DAL.Repositories
{
    /// <summary>
    /// Class:  GenericRepository
    /// Herencia:  IGenericRepository
    /// 
    /// Para evitar tener que reescribir codigo en cada repositorio, respetando el principio DRY, "No te repitas" (Don’t Repeat Yourself),
    /// Es que se trabaja con el patron generico de repositorios.
    /// En esta clase se implementan todas las operaciones CRUD que seran utilizadas por todos los repositorios, 
    /// <summary>
    /// <returns></returns>
 
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DamDbContext _context;

        public GenericRepository(DamDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            if (_context.Set<T>().Find(id) == null) throw new Exception($"No existe entidad con el identificador {id}");
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
