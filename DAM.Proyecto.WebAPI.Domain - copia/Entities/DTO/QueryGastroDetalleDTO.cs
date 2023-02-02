using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class QueryGastroDetalleDTO
    {
        public int Id { get; set; }
        public byte[]? Imagen { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? Direccion { get; set; }
        public string? Precio { get; set; }
        public string? Descripcion { get; set; }
        public string? Horario { get; set; }
        public string? URL { get; set; }
    }
}
