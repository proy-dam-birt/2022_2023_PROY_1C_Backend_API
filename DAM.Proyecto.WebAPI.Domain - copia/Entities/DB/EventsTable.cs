using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DB
{
    public class EventsTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventsId { get; set; }
        public int? TotalItems { get; set; }
        public int? TotalPages { get; set; }
        public int? CurrentPage { get; set; }
        public IList<EventoEuskadiTable> Evento { get; } = new List<EventoEuskadiTable>();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
