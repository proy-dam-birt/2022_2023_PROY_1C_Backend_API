﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DTO
{
    public class LoginDTO
    {
        public string? Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }

    }
}
