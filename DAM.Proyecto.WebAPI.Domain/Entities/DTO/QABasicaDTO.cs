using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO 
{
    
    public class QABasicaDTO
    {
        public QABasicaDTO() { }

        public int Id { get; set; }
        public string NameEs { get; set; }
        public string Tipo { get; set; }
        public string Coordenadas { get; set; } 
        public string imagePath { get; set; }

    }
}
