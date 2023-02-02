using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEventoEuskadiRepository EventoEuskadiRepo { get; }
        IImagesRepository ImagesRepo { get; }

        IGastronomiaEuskadiRepository GastronomiaEuskadiRepo { get; }
        IUserRepository UserRepo { get; }
        ITagsRepository TagsRepo { get; }
        IMaestroEventosRepository MaestroEventosRepo { get; }
        IReservaRepository ReservaRepo { get; }
        IFechasEventosRepository FechasEventosRepo { get; }
        IActividadesRepository ActividadesRepo { get; }

        IEventsRepository EventsRepo { get; }
        IFavoritosRepository FavoritosRepo { get; }
        Task SaveChanges();

        Task RollBack();
    }
}
