using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.Ent;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAM.Proyecto.WebAPI.SL.Services
{
    public class EnviarEmailService : IEnviarEmailService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow;

        #region Ctor
        public EnviarEmailService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        #endregion

        #region Public methods
        //TODO
        public async Task EnviarEmail(Reserva reserva)
        {

        }
        #endregion
    }
}

