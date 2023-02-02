using DAM.Proyecto.SL.Services;
using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.Ent;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using DAM.Proyecto.WebAPI.SL.Interfaces.IHelpers;
using DAM.Proyecto.WebAPI.SL.Services.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Services
{
    public class TramitarReservaService : ITramitarReservaService
    {
        private IUnitOfWork _uow;
        private IGeneradorQR _qR;
        private IGeneradorPDF _pDF;
        private IEnviarEmailService _eEmail;

        public TramitarReservaService(IUnitOfWork uow, IGeneradorQR qR, IGeneradorPDF pDF, IEnviarEmailService eEmail)
        {
            _uow = uow;
            _qR = qR;
            _pDF = pDF;
            _eEmail = eEmail;
        }
        public string TramitarReserva(int reservaId)
        {
            var res = _uow.ReservaRepo.GetById(reservaId);
            var tempo = _uow.FechasEventosRepo.GetById(res.FechasEventosTable);
            var actTemp = _uow.MaestroEventosRepo.GetById(_uow.FechasEventosRepo.GetById(res.FechasEventosTable).MaestroEventosTableId);
            //var act = _uow.EventoEuskadiRepo.GetById(actTemp.EventoId);
            var user = _uow.UserRepo.GetById(res.UserTable);
                Reserva reserva = new Reserva()
                {
                    ReservaNum = res.ReservaId,
                    FechaReservada = _uow.FechasEventosRepo.GetById(res.FechasEventosTable).FechaEvento,
                    Plazas = res.PlazasReservadas,
                    UserNombre = user.Nombre,
                    UserApellido = user.Apellido_1,
                    Actividad = actTemp.EventName,
                    Lugar = actTemp.Localizacion,
                    //URL = act.PurchaseUrlEs,
                    FechaTramitacion = DateTime.Now
                };

                string QR = _qR.generarQR(reserva);
              
                //_pDF.GenerarPdf(pdf);      
                //_eEmail.EnviarEmail(reserva);
            return QR;

        }
    }
}
