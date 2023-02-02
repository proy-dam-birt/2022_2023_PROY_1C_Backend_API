using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DB
{
    public class FavoritosTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FavoritosID { get; set; }
        
        [ForeignKey("EventId")]
        public int IDEvento { get; set; }

        [ForeignKey("Id")]
        public int IDUser { get; set; }

        public bool activo { get; set; }


    }
}
