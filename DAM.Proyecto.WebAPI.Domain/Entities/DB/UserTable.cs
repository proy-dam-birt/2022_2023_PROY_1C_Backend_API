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
    public class UserTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido_1 { get; set; }
        public string? Apellido_2 { get; set; }

        [Required]
        public string Email { get; set; }
        public string Telefono { get; set; }
        [Required]
        public bool Consumidor { get; set; }
        [Required]
        public bool Servuctor { get; set; }
        public string? Token { get; set; }
        public IList<ActividadesTable>? Favoritos = new List<ActividadesTable> { };

        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public void Update(UserTable src)
        {
            if (src == null)
                throw new ArgumentNullException("Source orderline is null");

            this.Username = Username;
            this.Password = Password;
            this.Apellido_2 = Apellido_2;
            this.Telefono = Telefono;
            this.Email = Email;
            this.Consumidor = Consumidor;
            this.Servuctor = Servuctor;

            this.UpdatedDateTime = DateTime.Now;
        }
    }
}
