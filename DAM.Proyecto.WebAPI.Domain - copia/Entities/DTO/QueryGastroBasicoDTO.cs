using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class QueryGastroBasicoDTO
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Precio { get; set; }
        public string Michelin { get; set; }
        public string Soles { get; set; }
    }
}
