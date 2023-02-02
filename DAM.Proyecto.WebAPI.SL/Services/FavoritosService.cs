using AutoMapper;
using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Services
{
    public class FavoritosService : IFavoritosService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;
        public FavoritosService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public dynamic updateFavorite(FavoritosTable favorito)
        {
            dynamic respuesta = new ExpandoObject();
            try
            {
                var maestroItem = _uow.MaestroEventosRepo.GetById(favorito.IDEvento);
                var imagen = maestroItem.imagePath;
                respuesta.ImagePath = imagen;
                var listaFavoritosUser = _uow.FavoritosRepo.Find(x => x.IDUser == favorito.IDUser).ToArray();

                if(listaFavoritosUser.Count() > 0)
                {
                    foreach (var item in listaFavoritosUser)
                    {
                        if (item.IDEvento == favorito.IDEvento)
                        {
                            if (item.activo)
                            {
                                item.activo = false;
                                _uow.FavoritosRepo.Update(item);
                                _uow.SaveChanges();
                                respuesta.activo = true;
                                return respuesta;
                            }
                            else
                            {
                                item.activo = true;
                                _uow.FavoritosRepo.Update(item);
                                _uow.SaveChanges();
                                respuesta.activo = true;
                                return respuesta;
                            }
                        }
                    }
                    _uow.FavoritosRepo.Add(favorito);
                    _uow.SaveChanges();
                    respuesta.activo = true;
                    return respuesta;
                }
                else
                {
                    _uow.FavoritosRepo.Add(favorito);
                    _uow.SaveChanges();
                    respuesta.activo = true;
                    return respuesta;
                }
            }
            catch
            {
                respuesta.activo = false;
                return respuesta;
            }
            throw new NotImplementedException();
        }

        public dynamic seeFavorite(int idUsuario, int idEvento)
        {
            try
            {
                dynamic respuesta = new ExpandoObject();
                var listaFavoritos = _uow.FavoritosRepo.GetAll().ToArray();
                var newList = listaFavoritos.Where(x => x.IDUser == idUsuario && x.IDEvento ==idEvento).FirstOrDefault();
                var maestroItem = _uow.MaestroEventosRepo.GetById(newList.IDEvento);

                respuesta.imagen = maestroItem.imagePath;
                respuesta.nombre = maestroItem.EventName;
                respuesta.favorito = newList.activo;
                respuesta.idEvento = newList.IDEvento;

                return respuesta;
            }
            catch
            {
                return null;
            }

            
        }

        public List<ExpandoObject> seeDetail(int idUsuario)
        {
            List<ExpandoObject> listaReservas = new List<ExpandoObject>();

            try
            {
                var listaFavoritos = _uow.FavoritosRepo.GetAll().ToArray();
                var newList = listaFavoritos.Where(x => x.IDUser == idUsuario && x.activo == true).ToArray();

                foreach (var item in newList)
                {
                    var maestro = _uow.MaestroEventosRepo.GetById(item.IDEvento);
                    var imagen = maestro.imagePath;

                    dynamic respuesta = new ExpandoObject();

                    respuesta.imagen = maestro.imagePath;
                    respuesta.nombre = maestro.EventName;
                    respuesta.favorito = true;
                    respuesta.idEvento = item.IDEvento;

                    listaReservas.Add(respuesta);

                   
                }
                return listaReservas;
            }
            catch
            {
                return null;
            }
            
            
            return null;
        }
    }

   

}
