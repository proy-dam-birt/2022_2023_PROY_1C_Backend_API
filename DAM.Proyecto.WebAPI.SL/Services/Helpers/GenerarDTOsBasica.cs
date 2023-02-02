using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces.IHelpers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Services.Helpers
{

    public class GenerarDTOsBasica : IGenerarDTOsBasica
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow;

        #region Ctor 
        public GenerarDTOsBasica(IUnitOfWork uow)
        {
            _uow = uow;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Genera listado con DTO Basicos de las actividades
        /// </summary>
        /// <param name="query">lista de consulta</param>
        /// <returns name="lista">IList&lt;QABasicaDTO&gt;lista</returns>

        public IList<QABasicaDTO> GenerarDTOBasico(IEnumerable< MaestroEventosTable> query)
        {
            _logger.Info($"Generando DTO Basico");
            IList<QABasicaDTO> lista = new List<QABasicaDTO>();
            try
            {

                foreach (var item in query)
                {
                    
                    lista.Add(new QABasicaDTO()
                    {
                        Id = item.EventId,
                        NameEs = item.EventName,
                       // Tipo = temp.TypeEs
                    });                                                          
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        /// <summary>
        /// Devuelve un listado de actividades de clase EventoEuskadi segun la lista query pasada por parametro
        /// </summary>
        /// <param name="query"></param>
        /// <returns name="lista">IList&lt;QABasicaDTO&gt;lista</returns>
        public IList<QABasicaDTO> GenerarDTOEvento(IList<EventoEuskadiTable> query)
        {
            _logger.Info($"GetActividad EVENTO x filtro");
            IList<QABasicaDTO> lista = new List<QABasicaDTO>();
            try
            {

                foreach (var item in query)
                {
                    
                    lista.Add(new QABasicaDTO()
                    {
                        Id = (int)item.ActividadesId,
                        NameEs = item.NameEs,

                    });
                }
                return lista;
            }
            
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Devuelve un listado de actividades de clase GastronomiaEuskadi segun la lista query pasada por parametro
        /// </summary>
        /// <param name="query"></param>
        /// <returns name="lista">IList&lt;QABasicaDTO&gt;lista</returns>
        public IList<QABasicaDTO> GenerarDTOGastro(IList<GastronomiaEuskadiTable> query)
        {
            _logger.Info($"GetActividad GASTRO x filtro");
            IList<QABasicaDTO> lista = new List<QABasicaDTO>();
            try
            {
                foreach (var item in query)
                {
                    lista.Add(new QABasicaDTO()
                    {
                        Id = (int)_uow.MaestroEventosRepo.Find(x => x.GastroId == item.GastroId).FirstOrDefault().GastroId,
                        NameEs = item.DocumentName,
                    });
                }
                Task.FromResult(lista);
            }
            catch (Exception ex)    
            {
                throw;
            }
            return lista;
        }
        #endregion
    }
}
