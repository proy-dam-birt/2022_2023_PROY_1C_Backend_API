using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido_1 { get; set; }
        public string? Apellido_2 { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Consumidor { get; set; }
        public bool Servuctor { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UltimaModificacion { get; set; }
    }
}
