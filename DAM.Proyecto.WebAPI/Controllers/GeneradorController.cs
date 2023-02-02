using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.Ent;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using DAM.Proyecto.WebAPI.SL.Interfaces.IHelpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DAM.Proyecto.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneradorController : ControllerBase
    {
        private IGeneradorQR _QR;
        private ITramitarReservaService _tr;
        public GeneradorController(IGeneradorQR QR, ITramitarReservaService tr)
        {
            _QR = QR;
            _tr = tr;
        }
        
        // POST api/Generador
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IResult Tramitar([FromBody] int reserva)
        {
            var resp = _tr.TramitarReserva(reserva);
                return Results.Created("Reserva", resp);
        }
        
        /*
        // POST api/Generador
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IResult Generar([FromBody] Reserva reserva)
        {
            var resp = _QR.generarQR(reserva);
            return Results.Created("Reserva", resp);
        }
        */
    }
}
