using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;
using ControlDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlDesk.Infrastructure.Repositories
{
    public class DepartmentRepository(ControlDeskContext context) : IDepartmentRepository
    {
        /// <summary>
        /// Metodo para obtener todos los departamentos
        /// </summary>
        /// <returns></returns>
        public Task<List<Department>> GetAllAsync() => context.Departments.ToListAsync();

        /// <summary>
        /// Metodo para obtener departamentos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Department?> GetByIdAsync(int id) => context.Departments.FindAsync(id).AsTask();

        /// <summary>
        /// Metodo para agregar departamentos
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Task AddAsync(Department department) => context.Departments.AddAsync(department).AsTask();

        /// <summary>
        /// Metodo para actualizar departamentos
        /// </summary>
        /// <param name="department"></param>
        public void Update(Department department) => context.Departments.Update(department);

        /// <summary>
        /// Metodo para eliminar departamentos
        /// </summary>
        /// <param name="department"></param>
        public void Delete(Department department) => context.Departments.Remove(department);
    }
}
