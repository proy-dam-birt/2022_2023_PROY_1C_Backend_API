using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO 
{ 
    public class QueryEventoBasicoDTO
    {
        public int Id { get; set; }
        public string NameEs { get; set; }
        public string EstablishmentEs { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
    }
}
