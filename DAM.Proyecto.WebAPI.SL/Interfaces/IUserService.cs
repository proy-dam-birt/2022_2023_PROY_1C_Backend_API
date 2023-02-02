using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Interfaces
{
    public interface IUserService
    {
        Task<QueryUserDTO> AddUser(UserDTO user);
        Task<QueryUserDTO> UpdateUser(UserDTO user);
        Task<QueryUserDTO> RemoveUser(UserDTO user);
        UserTable getUser(int id);
    } 
   
}
