using ControlDesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDesk.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Interface para obtener departamentos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Department?> GetByIdAsync(int id);

        /// <summary>
        /// Interface para obtener todos los departamentos
        /// </summary>
        /// <returns></returns>
        Task<List<Department>> GetAllAsync();

        /// <summary>
        /// Interface para agregar nueva departamento
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task AddAsync(Department department);

        /// <summary>
        /// Interface para actualizar departamento
        /// </summary>
        /// <param name="department"></param>
        void Update(Department department);

        /// <summary>
        /// Interface para eliminar departamento
        /// </summary>
        /// <param name="department"></param>
        void Delete(Department department);
    }
}
