
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAM.Proyecto.WebAPI.SL.Interfaces
{
    public interface ILoginService
    {
        Task<LoginDTO> ValidateLogin(LoginDTO user);

        ExpandoObject newLogin(string username, string password, string email);
    }
}
