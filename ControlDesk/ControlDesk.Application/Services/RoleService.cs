using ControlDesk.Application.DTOs;
using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class RoleService(IRoleRepository repository, IUnitOfWork unitOfWork)
    {
        /// <summary>
        /// Servicio para crear roles
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
        public async Task<int> CreateAsync(RoleDto dto)
        {
            try
            {
                Role role = new()
                {
                    RoleName = dto.RoleName,
                    CreatedDate = DateTime.Now
                };
                await repository.AddAsync(role);
                await unitOfWork.SaveChangesAsync();
                return role.RoleId;
            }
            catch (GenericException ex)
            {
                throw new GenericException("Exception: ", ex);
            }
        }

        /// <summary>
        /// Servicio para obtener roles
        /// </summary>
        /// <returns></returns>
        public async Task<List<Role>> GetAllAsync() => await repository.GetAllAsync();

        /// <summary>
        /// Servicio para actualizar roles
        /// </summary>
        /// <param name="roleObject"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
        public bool Update(Role? roleObject)
        {
            try
            {
                if (roleObject != null)
                {
                    repository.Update(roleObject);
                    unitOfWork.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (GenericException ex)
            {
                throw new GenericException("Exception: ", ex);
            }
        }

        /// <summary>
        /// Servicio para eliminar roles
        /// </summary>
        /// <param name="roleObject"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
        public bool Delete(Role? roleObject)
        {
            try
            {
                if (roleObject != null)
                {
                    repository.Delete(roleObject);
                    unitOfWork.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (GenericException ex)
            {
                throw new GenericException("Exception: ", ex);
            }
        }
    }
}
