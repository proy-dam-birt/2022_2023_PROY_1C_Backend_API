using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.Ent
{
    public class Reserva
    {
        public int ReservaNum { get; set; }
        public DateTime FechaReservada { get; set; }
        public int Plazas { get; set; }

        public string? UserNombre { get; set; }
        public string? UserApellido { get; set; }
       
        public string Actividad { get; set; }
        public string Lugar { get; set; }
       // public string? URL { get; set; }

        public DateTime FechaTramitacion { get; set; }
    }
}
