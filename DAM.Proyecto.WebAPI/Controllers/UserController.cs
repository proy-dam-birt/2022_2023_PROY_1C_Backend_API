using AutoMapper;
using Azure;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Mime;

namespace DAM.Proyecto.WebAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;
        public readonly IMapper _mapper;
        
        public UsersController(IMapper mapper, IUserService userSvc)
        {
            _mapper = mapper;
            _userService = userSvc;
        }
        
        // POST api/User
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(QueryUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IResult> Add([FromBody] UserDTO user)
        {
            var resp =await _userService.AddUser(user);
            var temp = 0;
            if (resp != null)
            {
                if ((resp.Username == "Username incorrecto") || (resp.Username == "Email incorrecto") || (resp.Username == "Username y email incorrecto"))
                {
                    return Results.Content(resp.Username);
                }
                /*if (resp.UltimaModificacion == DateTime.Now)
                {
                    return Results.BadRequest();
                }*/
                return Results.Created("Usuario Creado", resp);
            }
            return Results.BadRequest();
        }

        // PUT api/User
        [HttpPut()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(QueryUserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IResult> Update(string username, [FromBody] UserDTO user)
        {
            if (username == user.Username)
            {
                var resp = await _userService.UpdateUser(user);
                if (resp != null)
                {
                    if (resp.UltimaModificacion == DateTime.Now)
                    {
                        return Results.BadRequest();
                    }
                    return Results.Created("Usuario Modificado", resp);
                }
                return Results.BadRequest();
            }
            return Results.BadRequest();
        }

        // DELETE api/User
        [HttpDelete()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(QueryUserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IResult> Delete(string username, [FromBody] UserDTO value)
        {
            if (username == value.Username)
            {
                var resp = await _userService.RemoveUser(value);
                if(resp.UltimaModificacion == DateTime.Now)
                    {
                    return Results.BadRequest();
                }
                return Results.Created("Usuario Borrado", resp);
            }
            return Results.BadRequest();
        }

        [HttpGet]
        [Route("userInfo/{id}")]
        public IResult getUserInfo(int id)
        {
            var resp = _userService.getUser(id);

            return Results.Ok(resp);
        }
    }
}