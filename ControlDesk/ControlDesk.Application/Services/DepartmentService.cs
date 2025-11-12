using ControlDesk.Application.DTOs;
using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class DepartmentService(IDepartmentRepository repository, IUnitOfWork unitOfWork)
    {
        /// <summary>
        /// Servicio para crear departamento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
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

        /// <summary>
        /// Servicio para obtener los departamentos
        /// </summary>
        /// <returns></returns>
        public async Task<List<Department>> GetAllAsync() => await repository.GetAllAsync();

        /// <summary>
        /// Servicio para actualizar departamento
        /// </summary>
        /// <param name="departmentObject"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
        public bool Update(Department? departmentObject)
        {
            try
            {
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

        /// <summary>
        /// Servicio para eliminar departamento
        /// </summary>
        /// <param name="departmentObject"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
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
