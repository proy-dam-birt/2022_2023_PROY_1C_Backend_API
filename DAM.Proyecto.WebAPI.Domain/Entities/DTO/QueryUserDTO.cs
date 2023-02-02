using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class QueryUserDTO 
    {
        public QueryUserDTO()
        {
        }

        public QueryUserDTO(string username)
        {
            Username = username;
        }

        public QueryUserDTO(string v, DateTime dateTime)
        {
            V = v;
            DateTime = dateTime;
        }

        public QueryUserDTO(string username, string nombre, string apellido_1, string email, int Id)
        {
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_1 { get; set; }
        public string? Apellido_2 { get; set; }
        public string Username { get; set; }
        public bool consumidor { get; set; }
        public bool servuctor { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public string V { get; }
        public DateTime DateTime { get; }
        public bool validado { get; set; }
    }
}
