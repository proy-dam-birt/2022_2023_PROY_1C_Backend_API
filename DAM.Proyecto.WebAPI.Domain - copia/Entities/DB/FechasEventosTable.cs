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
    public class FechasEventosTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FechaEventosID { get; set; }
        [Required]
        public DateTime FechaEvento { get; set; }
        [Required]
        public int PlazasLibres { get; set; }

        [ForeignKey("EventId")]
        public MaestroEventosTable MaestroEventosTable { get; set; }
        


    }
}
