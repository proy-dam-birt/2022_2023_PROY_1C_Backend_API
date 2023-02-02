using AutoMapper;
using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;
using DAM.Proyecto.WebAPI.Domain.Entities.DTO;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Services
{
    public class UserService : IUserService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow;
        private IMapper _mapper;
        private IEnviarEmailService _enviarEmail;

        #region Ctor
        public UserService(IUnitOfWork uow, IMapper mapper, IEnviarEmailService enviarEmail)
        {
            _uow = uow;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Agrega el user si no existe
        /// Envia un email de informacion si la operacion ha sido correcta
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<QueryUserDTO> AddUser(UserDTO user)
        {
            /*await NoExisteUsername(user);
            await NoExisteEmail(user);*/
            var noExistUsername = NoExisteUsername(user);
            
            var noExistEmail = NoExisteEmail(user);
            
            if ((noExistUsername) && (noExistEmail))
            {
                return new QueryUserDTO("Username y email incorrecto");
            }
            if (noExistUsername)
            {
                return new QueryUserDTO("Username incorrecto");
            }
            if (noExistEmail) 
            {
                return new QueryUserDTO("Email incorrecto");
            }
            
            var itemT = _mapper.Map<UserTable>(user);

            try
            {
                //itemT.Favoritos = new List<ActividadesTable>();
                itemT.Token = "token";
                _uow.UserRepo.Add(itemT);
                await _uow.SaveChanges();

                var qUser = CreateQueryUserDTO(itemT);
                
                try
                {
                    //_enviarEmail.EnviarEmail(itemT);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    throw;
                }
                return qUser;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return new QueryUserDTO();
        }


        /// <summary>
        /// Actualiza el user si existe
        /// Envia un email de informacion si la operacion ha sido correcta
        /// </summary>
        /// <param name="userUPD"></param>
        /// <returns></returns>
        public async Task<QueryUserDTO> UpdateUser(UserDTO userUPD)
        {
            _logger.Info($"Se inicia UserService.Update {userUPD}");
            await ExisteUsername(userUPD);
            var userId = _uow.UserRepo.Find(x => x.Username == userUPD.Username).FirstOrDefault();
            var temp = _uow.UserRepo.GetById(userId.Id);
            var itemT = _mapper.Map<UserTable>(userUPD);
            try
            {
                // Se asignan los nuevos valores
                if (temp.Username != itemT.Username) temp.Username = itemT.Username;
                if (temp.Password != itemT.Password) temp.Password = itemT.Password;
                if (temp.Telefono != itemT.Telefono) temp.Telefono = itemT.Telefono;
                if (temp.Email != itemT.Email) temp.Email = itemT.Email;
                if (temp.Consumidor != itemT.Consumidor) temp.Consumidor = itemT.Consumidor;
                if (temp.Servuctor != itemT.Servuctor) temp.Servuctor = itemT.Servuctor;

                _uow.UserRepo.Update(temp);
                _uow.SaveChanges();

                _logger.Info($"Se han guardado los cambios del usuario {userId}, {userUPD.Username}");
                try
                {
                    //_enviarEmail.EnviarEmail(itemT);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    throw;
                }
                var qUser = CreateQueryUserDTO(itemT);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return new QueryUserDTO();
        }

        public async Task<QueryUserDTO> RemoveUser(UserDTO userDEL)
        {
            _logger.Info($"Se inicia UserService.Update {userDEL}");
            await ExisteUsername(userDEL);
            var userId = _uow.UserRepo.Find(x => x.Username == userDEL.Username).FirstOrDefault();
            var temp = _uow.UserRepo.GetById(userId.Id);
            var itemT = _mapper.Map<UserTable>(userDEL);
            try
            {
                // Se asignan los nuevos valores
               
                temp.Token = string.Empty;

                _uow.UserRepo.Update(temp);
                _uow.SaveChanges();

                _logger.Info($"Se han guardado los cambios del usuario {userId}, {userDEL.Username}");
                try
                {
                    //_enviarEmail.EnviarEmail(itemT);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    throw;
                }
                var qUser = CreateQueryUserDTO(itemT);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return new QueryUserDTO();
        }

        /*

        /// <summary>
        /// Elimina el user si existe 
        /// Envia un email de informacion si la operacion ha sido correcta
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<QueryUserDTO> RemoveUser(UserDTO userDEL)
        {
            _logger.Info($"Se inicia UserService.Update {userDEL}");
            var item = _mapper.Map<UserTable>(userDEL);
            await ExisteUsername(userDEL);
            await ExisteEmail(userDEL);
            var itemT =  _uow.UserRepo.Find(x => x.Username == item.Username).FirstOrDefault();
            var id =  _uow.UserRepo.GetById(itemT.Id);
            var temp = itemT;
            try
            {
                _uow.UserRepo.Remove(id);
                await _uow.SaveChanges();
                _logger.Info($"Se eliminado el usuario {userDEL}, {userDEL.Username}");
                try
                {
                    //_enviarEmail.EnviarEmail(temp);
                }
                catch (Exception ex)
                {
                    //_uow.RollBack();
                    _logger.Error(ex);
                    throw;
                }
                var qUser = CreateQueryUserDTO(itemT);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return new QueryUserDTO();
            
        }*/
        #endregion

        #region Private Methods
        /// <summary>
        /// verifica que ya Existe un usuario con ese Username
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /*private async Task NoExisteUsername(UserDTO user)
        {
            var temp = _uow.UserRepo.Find(x => x.Username == user.Username).FirstOrDefault();
            if (temp != null) throw new ApplicationException($"{user.Username.ToString()} ya existe");
        }*/
        private bool NoExisteUsername(UserDTO user)
        {
            var temp = _uow.UserRepo.Find(x => x.Username == user.Username).FirstOrDefault();
            if (temp != null) return true;
            return false;
        }

        /// <summary>
        /// Verifica que no existe un usuario con ese Username
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        private async Task ExisteUsername(UserDTO user)
        {
            var temp = _uow.UserRepo.Find(x => x.Username == user.Username).FirstOrDefault();
            if (temp == null) throw new ApplicationException($"{user.Username.ToString()} no existe");
        }


        /// <summary>
        /// Verifica que ya existe un usuario con ese email
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        /*private async Task NoExisteEmail(UserDTO user)
        {
            var temp = _uow.UserRepo.Find(x => x.Email == user.Email);
            if (temp != null && temp.Any()) throw new ApplicationException($"{user.Email.ToString()} ya existe");
        }*/

        private bool NoExisteEmail(UserDTO user)
        {
            var temp = _uow.UserRepo.Find(x => x.Email == user.Email);
            if (temp != null && temp.Any()) return true;
            return false;
        }

        /// <summary>
        /// Verifica que no existe un usuario con ese email
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        private async Task ExisteEmail(UserDTO user)
        {
            var temp = _uow.UserRepo.Find(x => x.Email == user.Email);
            if (temp == null) throw new ApplicationException($"{user.Email.ToString()} no existe");
        }

        private QueryUserDTO CreateQueryUserDTO (UserTable user)
        {
            QueryUserDTO qUser = new QueryUserDTO(user.Username, user.Nombre, user.Apellido_1, user.Email, user.Id)
            {
                Username = user.Username,
                Nombre = user.Nombre,
                Apellido_1 = user.Apellido_1,
                Email = user.Email,
                Id = user.Id
            };
            return qUser;
        }

        public UserTable getUser(int id)
        {
            var user = _uow.UserRepo.Find(x => x.Id == id).FirstOrDefault();

            if(user == null)
            {
                return null;
            }
            return user;

        }


        #endregion
    }
}
