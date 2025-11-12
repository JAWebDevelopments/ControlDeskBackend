using ControlDesk.Application.DTOs;
using ControlDesk.Domain.Common;
using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class UserService(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        public async Task<int> CreateAsync(UserDto userDto)
        {
            try
            {
                User user = new()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    Login = userDto.Login,
                    Password = Base64Helper.Encrypt(userDto.Password),
                    RoleId = userDto.RoleID,
                    DepartmentId = userDto.DepartmentID,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };
                await repository.AddAsync(user);
                await unitOfWork.SaveChangesAsync();
                return user.UserId;
            }
            catch (GenericException ex)
            {
                throw new GenericException("Exception: ", ex);
            }
        }

        public async Task<List<User>> GetAllAsync() => await repository.GetAllAsync();

        public bool Update(User? userObject)
        {
            try
            {
                if (userObject != null)
                {
                    repository.Update(userObject);
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

        public bool Delete(User? userObject)
        {
            try
            {
                if (userObject != null)
                {
                    repository.Delete(userObject);
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
