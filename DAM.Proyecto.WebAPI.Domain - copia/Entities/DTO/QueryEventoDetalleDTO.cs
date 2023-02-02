using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class QueryEventoDetalleDTO
    {
        public QueryEventoDetalleDTO (int id, byte[]? imagen, string nombre,string tipo, string direccion, string precio, string descripcion, string horario, string url)
        {
            Id = id;
            Imagen = imagen;
            Nombre = nombre;
            Tipo = tipo;
            Direccion = direccion;
            Precio = precio;
            Descripcion = descripcion;
            Horario = horario;
            URL = url; 
        }

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
