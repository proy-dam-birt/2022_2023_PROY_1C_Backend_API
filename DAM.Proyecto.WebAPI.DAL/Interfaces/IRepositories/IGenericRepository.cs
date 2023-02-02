using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories
{
    /// <summary>
    /// Interface: IGenericRepository
    /// Herencia: 
    /// 
    /// Es una interface generica que define metodos para aplicar a los repositorios que se creen.
    /// Las tablas que utilizamos tendran un atributo long como id, pero lo mas conveniente
    /// seria definir el id de tipo objeto, de forma que las tablas puedan tener diferentes tipos 
    /// de claves primarias
    /// 
    /// <summary>
    /// <returns></returns>
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
