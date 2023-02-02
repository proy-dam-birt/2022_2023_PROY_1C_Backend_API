using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.Ent
{
    public class Notificacion
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Subject { get; set; }
        public string[] Mensaje { get; set; }
    }
}
