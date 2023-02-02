using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DB
{
    public class ActividadesTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActividadId { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<EventoEuskadiTable>? EventoEus { get; } = new List<EventoEuskadiTable>();
        public IList<GastronomiaEuskadiTable>? GastroEus { get; } = new List<GastronomiaEuskadiTable>();
       
        [ForeignKey("TagId")]
        public TagsTable TagsTable { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
