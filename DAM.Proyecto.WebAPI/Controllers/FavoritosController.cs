using AutoMapper;
using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DAM.Proyecto.WebAPI.Controllers
{


    [ApiController]
    [Route("api/[Controller]")]
    public class FavoritosController
    {
        private readonly IMapper mapper;
        private readonly IFavoritosService _favoritoService;
        private IUnitOfWork _uow;

        public FavoritosController(IMapper mapper, IFavoritosService favoritoService)
        {
            this.mapper = mapper;
            this._favoritoService = favoritoService;

        }

        [HttpPost]
        public IResult updateFavorite(FavoritosTable favoritoData)
        {
            var resp = _favoritoService.updateFavorite(favoritoData);
            if (resp == null) { return Results.BadRequest(); }
            return Results.Ok(resp);
            
        }

        [HttpGet]
        [Route("{idUsuario}/{idEvento}")]
        public IResult seeFavorite(int idUsuario, int idEvento)
        {
            var resp = _favoritoService.seeFavorite(idUsuario, idEvento);
            if (resp == null) { return Results.BadRequest(); }
            return Results.Ok(resp); 
            
           
        }

        [HttpGet]
        [Route("{userId}")]
        public IResult seeDetail(int userId)
        {
            var resp = _favoritoService.seeDetail(userId);
            if (resp == null) { return Results.Ok("Este usuario no tiene favoritos"); }
            return Results.Ok(resp);
        }
    }
}
