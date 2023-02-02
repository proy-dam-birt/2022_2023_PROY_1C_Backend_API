using DAM.Proyecto.SL.Services;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Mime;

namespace DAM.Proyecto.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("Actividad")]            // es igual a [Route("[controller]")]
    [ApiController]


    public class ActividadController : ControllerBase
    {
        public readonly IActividadQueryIDService _actService;
        public readonly IActividadQueryGralService _gralService;

        public ActividadController(IActividadQueryIDService actService, IActividadQueryGralService gralService)
        {
            _actService = actService;
            _gralService = gralService;
        }


        /// <summary>
        /// Devuelve el resultado de la operacion solicitada y  
        /// un detalle de la actividad con id pasado por parametro, en formato Json 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IResult, QADetalleDTO</returns>
        /// Get api/Actividad/5
        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(QADetalleDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetActividad(int id)                                
        {
            var resp = await _actService.GetActividadByID(id);
            if (resp != null)
            {
                return Results.Created("Detalle actividad", resp);
            }
            return Results.BadRequest();
        }


       
        /// <summary>
        /// Devuelve el resultado de la operacion solicitada y  
        /// un detalle de la actividad con id pasado por parametro, en formato Json 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns>IResult, QADetalleDTO</returns>
        /// POST api/Actividades
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(QABasicaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IResult GetActividades([FromBody] QueryInput filtro)
        {
           var resp = _gralService.GetActividades(filtro);
            
                if (resp != null && resp.Any())
                {
                    return Results.Created("Lista actividades", resp);
                }
                return Results.BadRequest();

          }
    }
}
