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
        public int Id { get; set; }
        public string Name { get; set; }
        public string? TipoActividad { get; set; }
        public bool Activa { get; set; }

        public int? GastroId { get; set; }
        public int? EventoId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public void Update(ActividadesTable src)
        {
            if (src == null)
                throw new ArgumentNullException("Source orderline is null");

            this.Name = Name;
            this.TipoActividad = TipoActividad;
            this.Activa = Activa;
            this.UpdatedDateTime = DateTime.Now;
        }
    }
}
