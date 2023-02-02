
using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace DAM.Proyecto.WebAPI.SL.Services
{
    public class ActividadQueryIDService : IActividadQueryIDService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow;

        #region Ctor
        public ActividadQueryIDService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Devuelve el detalle de la actividad con el id pasado por parametro
        /// </summary>
        /// <param name="id" type="int"></param>
        /// <returns name="lista">IList&lt;QADetalleDTO&gt;lista</returns>
        public Task<QADetalleDTO> GetActividadByID(int id)
        {
            try
            {
                
                //int precio = precioAleatorio.Next(10, 100);
                var actividad = _uow.MaestroEventosRepo.GetById(id);
                QADetalleDTO actv;
                string tipo, direccion, precio, descripcion, horario, url, coordenadas;

                if (actividad.EventoId != null && actividad.EventoId > -1)
                {
                    int ie = (int)actividad.EventoId;
                    EventoEuskadiTable temp = _uow.EventoEuskadiRepo.Find(x => x.EventoEuskadiId == ie).FirstOrDefault();

                    direccion = temp.EstablishmentEs;
                    if (temp.PriceEu == null) temp.PriceEu = "no definido";
                    precio = temp.PriceEu;
                    if (temp.DescriptionEs == null) temp.DescriptionEs = "no definido";
                    descripcion = temp.DescriptionEs;
                    if (temp.OpeningHoursEu == null) temp.OpeningHoursEu = "no definido";
                    horario = temp.OpeningHoursEu;
                    url = temp.UrlEventEs;
                    coordenadas = temp.MunicipalityLatitude + "," + temp.MunicipalityLongitude;
                    
                    QADetalleDTO ev = new QADetalleDTO()
                    {
                        Id = (int)id,
                        Imagen = actividad.imagePath,                                               //TODO  temp.Images,
                        Nombre = actividad.EventName,
                        Tipo = temp.TypeEs,
                        Direccion = direccion,
                        Precio = precio,
                        Descripcion = descripcion,
                        Horario = horario,
                        URL = url,
                        Coordenadas = coordenadas 
                    };
                    return Task.FromResult(ev);
                }

                if (actividad.GastroId != null && actividad.GastroId > -1)
                {
                    Random precioAleatorio = new Random();
                    
                    int ig = (int)actividad.GastroId;
                    var g = _uow.GastronomiaEuskadiRepo.GetById(ig);
                    tipo = g.RestorationType;
                    direccion = g.Address;
                    precio = "" + precioAleatorio.Next(10, 100);
                    descripcion = "Estrellas Michelin: " + g.MichelinStar + "\nSoles: " + g.RepsolSun;
                    horario = "no definido";
                    url = g.Web;                    

                    QADetalleDTO gas = new QADetalleDTO()
                    {
                        Id = (int)id,
                        Imagen = actividad.imagePath,                                               //TODO  temp.Images,
                        Nombre = actividad.EventName,
                        Tipo = tipo,
                        Direccion = direccion,
                        Precio = precio,
                        Descripcion = descripcion,
                        Horario = horario,
                        URL = url
                    };

                    return Task.FromResult(gas);
                }
            return null;
            }
            catch (SystemException e)
            {
                _logger.Error(e);
                throw;
            }
            catch(Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }
        #endregion
    }
}