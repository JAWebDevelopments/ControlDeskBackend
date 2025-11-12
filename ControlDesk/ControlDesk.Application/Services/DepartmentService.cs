using ControlDesk.Application.DTOs;
using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class DepartmentService(IDepartmentRepository repository, IUnitOfWork unitOfWork)
    {
        public async Task<int> CreateAsync(DepartmentDto dto)
        {
            try
            {
                Department department = new()
                {
                    DepartmentName = dto.DepartmentName,
                    DepartmentDescription = dto.DepartmentDescription,
                    CreatedDate = DateTime.Now,
                };
                await repository.AddAsync(department);
                await unitOfWork.SaveChangesAsync();
                return department.DepartmentId;
            }
            catch (GenericException ex)
            {
                throw new GenericException("Exception: ", ex);
            }
        }

        public async Task<List<Department>> GetAllAsync() => await repository.GetAllAsync();

        public bool Update(Department? departmentObject)
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

                if (departmentObject != null)
                {
                    repository.Update(departmentObject);
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

        public bool Delete(Department? departmentObject)
        {
            try
            {
                if (departmentObject != null)
                {
                    repository.Delete(departmentObject);
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
