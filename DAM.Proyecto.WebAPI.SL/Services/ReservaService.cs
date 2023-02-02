using AutoMapper;
using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using static System.Formats.Asn1.AsnWriter;
using DAM.Proyecto.WebAPI.Domain.Entities.Ent;


namespace DAM.Proyecto.SL.Services
{
   
    public class ReservaService : IReservaService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;
        private ITramitarReservaService _tramitar;
        public ReservaService(IUnitOfWork uow, IMapper mapper, ITramitarReservaService tramitar)
        {
            _uow = uow;
            _mapper = mapper;
            _tramitar= tramitar;
        }


       /* public ExpandoObject CreateReserva(ReservaDTO reserva)
        {
            try
            {
                var fItem = _uow.FechasEventosRepo.GetById(reserva.FechaEventosID);
                var uItem = _uow.UserRepo.GetById(reserva.UserId);
                var mItem = _uow.MaestroEventosRepo.GetById(fItem.MaestroEventosTableId);
                var plazasLibres = fItem.PlazasLibres;
                var plazasReservadas = reserva.PlazasReservadas;

                if (plazasLibres >= plazasReservadas)
                {
                    ReservaTable reservaItem = new ReservaTable();

                    reservaItem.UserTable = uItem.Id;
                    reservaItem.FechasEventosTable = fItem.FechaEventosID;
                    reservaItem.PlazasReservadas = reserva.PlazasReservadas;
                    reservaItem.CreatedDateTime = DateTime.Now;
                    reservaItem.UpdatedDateTime = DateTime.Now;

                    _uow.ReservaRepo.Add(reservaItem);
                    _uow.SaveChanges();
                    plazasLibres = plazasLibres - plazasReservadas;

                    fItem.PlazasLibres = plazasLibres;
                    _uow.FechasEventosRepo.Update(fItem);
                    _uow.SaveChanges();

                    dynamic respuesta = new ExpandoObject();

                    respuesta.fechaEvento = fItem.FechaEvento;
                    respuesta.nombreEvento = mItem.EventName;
                    respuesta.localizacion = mItem.Localizacion;
                    respuesta.nombreUsuario = uItem.Nombre;
                    respuesta.plazasReservadas = reserva.PlazasReservadas;
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }

            return null;
        }*/
        public ExpandoObject CreateReserva(int idUser, int idMaestro, int plazasReservadas, DateTime fecha)
        {
            ReservaTable reservaItem = new ReservaTable();
            dynamic respuesta = new ExpandoObject();

            try
            {
                var fItem = _uow.FechasEventosRepo.Find(x => x.MaestroEventosTableId == idMaestro).ToArray();

                foreach(var item in fItem)
                {
                    if(item.FechaEvento == fecha)
                    {
                        if(item.PlazasLibres > plazasReservadas)
                        {
                            reservaItem.UserTable = idUser;
                            reservaItem.FechasEventosTable = item.FechaEventosID;
                            reservaItem.PlazasReservadas = plazasReservadas;
                            reservaItem.CreatedDateTime = DateTime.Now;
                            reservaItem.UpdatedDateTime = DateTime.Now;

                            _uow.ReservaRepo.Add(reservaItem);
                            _uow.SaveChanges();

                            item.PlazasLibres = item.PlazasLibres - plazasReservadas;

                            _uow.FechasEventosRepo.Update(item);
                            _uow.SaveChanges();

                            var maestroTable = _uow.MaestroEventosRepo.Find(x => x.EventId == idMaestro).FirstOrDefault();
                            

                            respuesta.fechaEvento = item.FechaEvento;
                            respuesta.nombreEvento = maestroTable.EventName;
                            respuesta.localizacion = maestroTable.Localizacion;
                            respuesta.nombreUsuario = maestroTable.EventName;
                            respuesta.plazasReservadas = plazasReservadas;
                            respuesta.imagen = maestroTable.imagePath;
                            return respuesta;

                            
                        }
                        else
                        {
                            respuesta.mensaje = "Plazas agotadas";
                            return respuesta;
                        }
                    }
                }
                respuesta.mensaje = "Evento no dispnble"; 
                return respuesta;

                return null;
            }
            catch
            {
                return null;
            }

            return null;
        }

        public List<ExpandoObject> getReservas(int idstring)
        {
            try
            {
                var userName = _uow.UserRepo.GetById(idstring);
                var userReserves = _uow.ReservaRepo.Find(x => x.UserTable == idstring);
                var reserves = userReserves.ToList();

                
                List<ExpandoObject> listaReservas = new List<ExpandoObject>();

                foreach (var item in reserves)
                {
                    dynamic respuesta = new ExpandoObject();
                    var reservaID = item.FechasEventosTable;
                    var fItem = _uow.FechasEventosRepo.Find(x => x.FechaEventosID == reservaID).FirstOrDefault();
                    var mItem = _uow.MaestroEventosRepo.GetById(fItem.MaestroEventosTableId);
                    respuesta.IdReserva = item.ReservaId;
                    respuesta.fechaEvento = fItem.FechaEvento;
                    respuesta.nombreEvento = mItem.EventName;
                    respuesta.localizacion = mItem.Localizacion;
                    respuesta.plazasReservadas = item.PlazasReservadas;
                    respuesta.imagen = mItem.imagePath;

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
        
       /*public List<ExpandoObject> getAllReservas(string fecha, int numPersonas, string localizacion, string tipo)
        {
            try
            {
                dynamic respuesta = new ExpandoObject();
                var respuestaList = new List<ExpandoObject>();

                var filtroPlazas = _uow.FechasEventosRepo.Find(x => x.PlazasLibres >= numPersonas);
                var filtroPlazasArray = filtroPlazas.ToArray();
                for (int i = 0; i < filtroPlazasArray.Length; i++)
                {

                    if (filtroPlazasArray[i].FechaEvento.ToString("dd/MM/yyyy") == fecha)
                    {
                        var maestro = _uow.MaestroEventosRepo.GetById(filtroPlazasArray[i].MaestroEventosTableId);
                        respuesta.eventName = maestro.EventName;
                        respuesta.fechaEvento = fecha;
                        respuesta.localizacion = maestro.Localizacion;
                        respuesta.tipo = tipo;
                        respuestaList.Add(respuesta);
                    }
                }
                return respuestaList;
            }
            catch
            {
                return null;
            }

            throw new NotImplementedException();
        }*/

        List<ExpandoObject> IReservaService.getAvailable()
        {
            dynamic reserva = new ExpandoObject();
            var respuestaList = new List<ExpandoObject>();

            var localizacionList = new List<string>();
            var dateList = new List<DateTime>();
            try
            {
                var reservas = _uow.FechasEventosRepo.GetAll();
                foreach (var reservo in reservas)
                {
                    var maestro = _uow.MaestroEventosRepo.GetById(reservo.MaestroEventosTableId);
                    var fecha = reservo.FechaEvento;
                    if (!dateList.Contains(fecha)) { dateList.Add(fecha); }
                    if (!localizacionList.Contains(maestro.Localizacion)) { localizacionList.Add(maestro.Localizacion); }

                }
                reserva.localizaciones = localizacionList;
                reserva.fechas = dateList;
                respuestaList.Add(reserva);
                
                return respuestaList;
            }
            catch
            {
                return null;
            }
            throw new NotImplementedException();
        }

        public ExpandoObject CreateReserva(ReservaDTO Reserva)
        {
            throw new NotImplementedException();
        }
    }
}
