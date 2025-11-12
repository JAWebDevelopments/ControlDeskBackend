using ControlDesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDesk.Domain.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// obtener role por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Role?> GetByIdAsync(int id);

        /// <summary>
        /// obtener todos los roles
        /// </summary>
        /// <returns></returns>
        Task<List<Role>> GetAllAsync();

        /// <summary>
        /// agregar nuevo role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task AddAsync(Role role);

        /// <summary>
        /// actualizar role
        /// </summary>
        /// <param name="role"></param>
        void Update(Role role);

        /// <summary>
        /// eliminar role
        /// </summary>
        /// <param name="role"></param>
        void Delete(Role role);
    }
}
