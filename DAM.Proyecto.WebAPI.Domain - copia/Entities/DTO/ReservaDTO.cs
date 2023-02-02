﻿using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class ReservaDTO
    {
        public int ReservaId { get; set; }
        public long UserId { get; set; }
        public long FechaEventosID { get; set; }
        public int PlazasReservadas { get; set; }

        
    }
}
