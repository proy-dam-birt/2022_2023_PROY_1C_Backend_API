using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.DAL.Repositories
{
    /// <class name="UnitOfWork"></class>
    /// <herencia name ="IUnitOfWork"></herencia>
    /// <summary>    
    /// Unit of works es como una business transaction. Este patrón fusionará todas las transacciones CRUD de los repositorios
    /// en una sola transacción.Todos los cambios se confirmarán una sola vez. 
    /// La principal ventaja es que la capa de aplicación necesitará conocer sólo una clase (UnitOfWork) para acceder a cada repositorio.
    /// Pero ademas, cuando haya varios componentes del repositorio que deban invocarse o procesarse para una sola solicitud, 
    /// comparta un contexto de base de datos común.
    /// De esta manera, podemos reducir el número de veces que se realiza una conexión de base de datos 
    /// para la transacción cuando estos componentes del repositorio se usan por separado.
    /// 
    /// Por ejemplo, se hacen muchos updates en una tabla, pero solo se guardaran al ejecutar  el metodo SaveChanges.
    /// <summary>

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DamDbContext _context;

        public IEventoEuskadiRepository EventoEuskadiRepo { get; private set; }

        public IImagesRepository ImagesRepo { get; private set; }
        public IGastronomiaEuskadiRepository GastronomiaEuskadiRepo { get; private set; }

        public IUserRepository UserRepo { get; private set; }
        public ITagsRepository TagsRepo { get; private set; }
        public IMaestroEventosRepository MaestroEventosRepo { get; private set; }
        public IReservaRepository ReservaRepo { get; private set; }
        public IFechasEventosRepository FechasEventosRepo { get; private set; }
        public IActividadesRepository ActividadesRepo { get; private set; }
        public IEventsRepository EventsRepo { get; private set; }
        public IFavoritosRepository FavoritosRepo { get; private set; }

        #region Ctr
        /// <summary>
        /// Con el constructor solo se esta inicializando la variable de contexto
        /// estamos almacenando el objeto DBContext(DamDBContext) en _context variable
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(DamDbContext context)
        {
            _context = context;
            EventoEuskadiRepo = new EventoEuskadiRepository(_context);
            ImagesRepo = new ImagesRepository(_context);
            GastronomiaEuskadiRepo = new GastronomiaEuskadiRepository(_context);
            UserRepo = new UserRepository(_context);
            TagsRepo = new TagsRepository(_context);
            MaestroEventosRepo = new MaestroEventosRepository(_context);
            ReservaRepo = new ReservaRepository(_context);
            FechasEventosRepo = new FechasEventosRepository(_context);
            ActividadesRepo = new ActividadesRepository(_context);
            EventsRepo = new EventsRepository(_context);
            FavoritosRepo = new FavoritosRepository(_context);
        }
        #endregion

        /// <summary>
        /// Method: SaveChanges()
        /// Access: public
        /// <summary>
        /// <return type="int"></return>
        public async Task SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task RollBack()
        {
            await _context.RollBack();
        }

        /// <metodo name="Dispose"></metodo>
        /// <acceso>publico</acceso>
        /// <summary>
        /// El método Dispose() se utiliza para liberar recursos no administrados 
        /// como conexiones de bases de datos de archivos, etc. en cualquier momento.
        /// <summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
