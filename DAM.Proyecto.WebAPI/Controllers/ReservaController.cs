using AutoMapper;
using DAM.Proyecto.SL.Services;
using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;

namespace DAM.Proyecto.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IReservaService _reservaService;
        private IUnitOfWork _uow;

        public ReservaController(IMapper mapper, IReservaService reservaService)
        {
            this.mapper = mapper;
            this._reservaService = reservaService;

        }
       
        [HttpPost]
        public IResult CreateReserva(int idUsuario, int IdMaestro, int plazasReservadas, DateTime fecha)
        {
            var temp = 0;
            var temp1 = fecha.ToString();

            if ((idUsuario == 0) || (IdMaestro == 0) || (plazasReservadas == 0) || (fecha.ToString() == "01/01/0001 0:00:00"))
            {
                return Results.BadRequest("Completa todos los datos");
            }
            var resp = _reservaService.CreateReserva(idUsuario, IdMaestro, plazasReservadas, fecha);
            

            if (resp != null) { return Results.Json(resp); }

            return Results.BadRequest();
        }


        /*[HttpGet]
        public IResult getAllReservas(string fecha, int numPersonas, string localizacion, string tipo)
        {
            var resp = _reservaService.getAllReservas(fecha, numPersonas, localizacion, tipo);
            var count = resp.Count();
            
            if (resp.Count() > 0) { return Results.Json(resp); }
            else if (count == 0) { return Results.NoContent(); }
            
            return Results.BadRequest();
        }*/

        [HttpGet]
        [Route("{id}")]
        public IResult getReserva(int userId)
        {
            var resp = _reservaService.getReservas(userId);
            var count = resp.Count();

            if (resp.Count() > 0) { return Results.Json(resp); }
            else if (count == 0) { return Results.NoContent(); }

            return Results.BadRequest();
        }

        [HttpGet]
        [Route("available")]
        public IResult getAllReservas()
        {
            var resp = _reservaService.getAvailable();
            var count = resp.Count();

            if (resp.Count() > 0) { return Results.Json(resp); }
            else if (count == 0) { return Results.NoContent(); }

            return Results.BadRequest();
        }
    }
}
    

