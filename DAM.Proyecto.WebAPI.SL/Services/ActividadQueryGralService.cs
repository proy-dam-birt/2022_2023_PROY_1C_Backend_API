using Azure;
using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using DAM.Proyecto.WebAPI.SL.Interfaces.IHelpers;
using DAM.Proyecto.WebAPI.SL.Services.Helpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Services
{
    public class ActividadQueryGralService : IActividadQueryGralService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public IGenerarDTOsBasica _generar;
        private IUnitOfWork _uow;

        public ActividadQueryGralService(IUnitOfWork uow, IGenerarDTOsBasica generar)
        {
            _uow = uow;
            _generar = generar;
        }

        #region Public methods
        /// <summary>
        /// Devuelve un listado con todas las actividades que estan activas                            
        /// </summary>
        /// <returns name="lista">IList&lt;QABasicaDTO&gt;lista</returns>
        public IList<QABasicaDTO> GetActividades(QueryInput input)
        {
            try
            {
                IList<QABasicaDTO> lista = new List<QABasicaDTO>();
                var tempAct = _uow.MaestroEventosRepo.Find(x => x.Estado).ToList();

                var tempFech = _uow.FechasEventosRepo.GetAll().ToList();

                // CASO 1: TODOS       <=> filtros: localizacion, personas, fecha, tipo: todos
                if (input.Evento == null && input.Gastro == null)
                {
                    var query1 = from MAT in tempAct
                                 join FET in tempFech on MAT.EventId equals FET.MaestroEventosTableId
                                 let f = FET.FechaEvento == DateTime.Parse(input.Fecha)
                                 let l = MAT.Localizacion == input.Localidad
                                 where f && FET.PlazasLibres - input.Personas >= 0 && f && l
                                 select new
                                 {
                                     Actividad = MAT.EventId,
                                 };

                    foreach (var item in query1)
                    {
                        string tipo;

                        var temp = _uow.MaestroEventosRepo.Find(x => x.EventId == item.Actividad).FirstOrDefault();

                        if (temp.EventoId > 0)
                        {
                            tipo = _uow.EventoEuskadiRepo.GetById(temp.EventoId).TypeEs.ToString();

                            lista.Add(new QABasicaDTO()
                            {
                                Id = item.Actividad,
                                NameEs = temp.EventName,
                                Tipo = tipo,
                                Coordenadas = temp.Coordenadas,
                                imagePath = temp.imagePath
                            });
                        }
                        if (temp.GastroId > 0)
                        {
                            tipo = _uow.GastronomiaEuskadiRepo.GetById(temp.GastroId).RestorationType.ToString();

                            lista.Add(new QABasicaDTO()
                            {
                                Id = item.Actividad,
                                NameEs = temp.EventName,
                                Tipo = tipo,
                                Coordenadas = temp.Coordenadas,
                                imagePath = temp.imagePath
                            });
                        }
                    }
                    return lista;
                }

                // CASO 2: EVENTOS       <=> filtros: localizacion, personas, fecha, Tipo EVENTO
                if (input.Evento == null && input.Gastro != null)
                {
                    var query2 = from MAT in tempAct
                                 join FET in tempFech on MAT.EventId equals FET.MaestroEventosTableId
                                 let f = FET.FechaEvento == DateTime.Parse(input.Fecha)
                                 let l = MAT.Localizacion == input.Localidad
                                 where f && FET.PlazasLibres - input.Personas >= 0 && f && l && MAT.EventoId > 0
                                 select new
                                 {
                                     Actividad = MAT.EventId,
                                 };

                    foreach (var item in query2)
                    {
                        string tipo;
                        var temp = _uow.MaestroEventosRepo.Find(x => x.EventId == item.Actividad).FirstOrDefault();
                        tipo = _uow.EventoEuskadiRepo.GetById(temp.EventoId).TypeEs.ToString();

                        lista.Add(new QABasicaDTO()
                        {
                            Id = item.Actividad,
                            NameEs = temp.EventName,
                            Tipo = tipo,
                            Coordenadas = temp.Coordenadas,
                            imagePath = temp.imagePath
                        });
                    }
                    return lista;

                }

                // CASO 2: GASTRO       <=> filtros: localizacion, personas, fecha, Tipo GASTRO
                if (input.Evento != null && input.Gastro == null)
                {
                    var query3 = from MAT in tempAct
                                 join FET in tempFech on MAT.EventId equals FET.MaestroEventosTableId
                                 let f = FET.FechaEvento == DateTime.Parse(input.Fecha)
                                 let l = MAT.Localizacion == input.Localidad
                                 where f && FET.PlazasLibres - input.Personas >= 0 && f && l && MAT.GastroId > 0
                                 select new
                                 {
                                     Actividad = MAT.EventId,
                                 };

                    foreach (var item in query3)
                    {
                        string tipo;
                        var temp = _uow.MaestroEventosRepo.Find(x => x.GastroId == item.Actividad).FirstOrDefault();
                        tipo = _uow.GastronomiaEuskadiRepo.GetById(temp.GastroId).RestorationType.ToString();

                        lista.Add(new QABasicaDTO()
                        {
                            Id = item.Actividad,
                            NameEs = temp.EventName,
                            Tipo = tipo,
                            Coordenadas = temp.Coordenadas,
                            imagePath = temp.imagePath
                        });
                    }
                    return lista;
                }
                return lista;
            } 
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
