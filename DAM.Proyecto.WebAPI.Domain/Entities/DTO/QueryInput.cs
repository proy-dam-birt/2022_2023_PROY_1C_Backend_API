using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class QueryInput
    {
        public string Localidad { get; set; }
        public int  Personas { get; set; }
        public string Fecha { get; set; }
        public int? Evento { get; set; }
        public int? Gastro { get; set; }
        public int? ActividadId { get;}
    }
}
