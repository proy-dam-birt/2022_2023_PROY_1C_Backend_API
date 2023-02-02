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
        
        [Required]
        public string EventName { get; set; }
        
        [Required]
        public string Localizacion { get; set; }
        public string Coordenadas  { get; set; }
        
        [ForeignKey("TagId")]
        public TagsTable TagsTable { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

    }
}
