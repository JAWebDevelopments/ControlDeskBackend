using ControlDesk.Application.DTOs;
using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class RoleService(IRoleRepository repository, IUnitOfWork unitOfWork)
    {
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

        public async Task<List<Role>> GetAllAsync() => await repository.GetAllAsync();

        public bool Update(Role? roleObject)
        {
            try
            {
                /*Ticket ticket = new()
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    State = dto.State,
                    Priority = dto.Priority,
                    CreatedDate = dto.CreatedDate,
                    UserIdCreated = dto.UserIdCreated,
                    UserIdAssigned = dto.UserIdAssigned
                };*/

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
