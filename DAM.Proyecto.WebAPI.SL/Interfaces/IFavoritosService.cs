﻿using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Interfaces
{
    public interface IFavoritosService
    {
        //public ExpandoObject addFavorite(FavoritosTable favorito);

        public dynamic updateFavorite(FavoritosTable favorito);
        public dynamic seeFavorite(int idUsuario, int idEvento);
        public List<ExpandoObject> seeDetail(int idUsuario);

    }
}
