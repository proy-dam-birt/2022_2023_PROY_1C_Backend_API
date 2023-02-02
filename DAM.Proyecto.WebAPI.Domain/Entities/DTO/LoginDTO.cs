using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class LoginDTO
    {
        private LoginDTO user;

        public LoginDTO()
        {
        }

        public LoginDTO(LoginDTO user)
        {
            this.user = user;
        }

        public string? Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public bool? Validado { get; set; }

    }
}
