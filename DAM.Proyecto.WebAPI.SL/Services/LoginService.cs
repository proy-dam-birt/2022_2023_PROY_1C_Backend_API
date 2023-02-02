using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DAM.Proyecto.SL.Services
{
    public class LoginService : ILoginService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow;
        
        public LoginService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ExpandoObject newLogin(string username, string password, string email)
        {
            var user = new UserTable();
            dynamic respuesta = new ExpandoObject();
            user = _uow.UserRepo.Find(x => x.Username == username).FirstOrDefault();

            if (user == null)
            {
                user = _uow.UserRepo.Find(x => x.Email == email).FirstOrDefault();
                if (user == null)
                {
                    respuesta.mensaje = "Usuario incorrecto";
                }
            }
            var userBBDDname = user.Username;
            var userBBDDpass = user.Password;
            var userBBDDemail = user.Email;

            if (userBBDDpass != password)
            {
                respuesta.mensaje = "contraseña incorrecta"; 
                return respuesta; // password incorrecto
            }

            if((userBBDDemail != email) && (userBBDDname != username))
            {
                if (userBBDDname != username)
                {
                    respuesta.mensaje = "usuario o email incorrecto";
                    return respuesta; // usuario o email incorrecto
                }
                respuesta.mensaje = "usuario o email incorrecto";
                return respuesta; // usuario o email incorrecto

            }
            respuesta.mensaje = "Login correcto";
            respuesta.username = username;
            respuesta.email = email;
            respuesta.id = user.Id;
            
            return respuesta;
        }


        public async Task<LoginDTO> ValidateLogin(LoginDTO user)
        {
            LoginDTO qUser = new LoginDTO(user)
            {
                Username = user.Username,
                Email = user.Email,
                Validado = false
            };

            try
            {
                var query = _uow.UserRepo.Find(x => x.Username == user.Username).FirstOrDefault();

                if (query != null)
                {
                    if (query.Password == user.Password)
                    {
                        return qUser;
                    }
                }
                query = _uow.UserRepo.Find(x => x.Email == user.Email).FirstOrDefault();
                if (query != null && query.Token != string.Empty)
                {
                    if (query.Password == user.Password)
                    {
                        return qUser;
                    }
                }
                return new LoginDTO(); 
            }           
            catch (SqlException ex)
            {               
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
