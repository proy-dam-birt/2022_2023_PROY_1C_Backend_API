using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DB
{
    public class ReservaTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservaId { get; set; }

        [ForeignKey("Id")]
        public int UserTable { get; set; }

        //Foreign key tabla Fechas
        [ForeignKey("FechaEventosID")]
        public int FechasEventosTable { get; set; }

        [Required]
        public int PlazasReservadas { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        
    }
}
