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
        public long TotalItems { get; set; }
        public long TotalPages { get; set; }
        public long CurrentPage { get; set; }
        public IList<EventoEuskadiTable>? Eventos { get; } = new List<EventoEuskadiTable>();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
