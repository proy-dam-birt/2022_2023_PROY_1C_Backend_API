using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DB
{
    public class MaestroEventosTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        
        public string EventName { get; set; }
        
        public string Localizacion { get; set; }
        public string Coordenadas  { get; set; }
        
       
        public string imagePath { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
            
        public bool Estado { get; set; }
        public int? GastroId { get; set; }
        public int? EventoId { get; set; }  

    }
}
