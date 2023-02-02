using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class QADetalleDTO
    {
        public QADetalleDTO()
        {
        }

        public QADetalleDTO(object tipo, object direccion, object precio, object descripcion, object horario, object url)
        {
        }

        public QADetalleDTO (int id, string? imagen, string nombre,string tipo, string direccion, string precio, string descripcion, string horario, string url, string coordenadas)
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
            Coordenadas = coordenadas;
        }

        public int Id { get; set; }
        public string? Imagen { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? Direccion { get; set; }
        public string? Precio { get; set; }
        public string? Descripcion { get; set; }
        public string? Horario { get; set; }
        public string? URL { get; set; }
        public string Coordenadas { get; set; }
    }
}
