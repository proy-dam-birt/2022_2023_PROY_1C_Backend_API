using AutoMapper;
using Azure.Core.GeoJson;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Mime;

namespace DAM.Proyecto.WebAPI.Controllers
{
    //[Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        // POST api/<LoginController>
        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(LoginDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IResult> Login(LoginDTO user)
        {
            LoginDTO querylogin = new LoginDTO();
            querylogin = await _loginService.ValidateLogin(user);
            if (querylogin.Validado == false )
            {
                return Results.Created("login valido", querylogin);
            }
            return Results.BadRequest();
        }

        [HttpPost]
        [Route("newLogin")]
        public IResult newLogin(string? username = null, string password = null, string? email = null)
        {
            var resp = _loginService.newLogin(username, password, email);
            if(resp != null) return Results.Ok(resp);
            return Results.BadRequest();
        }
    }
}
