using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;
using ControlDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDesk.Infrastructure.Repositories
{
    public class RoleRepository(ControlDeskContext context) : IRoleRepository
    {
        /// <summary>
        /// Metodo para obtener todos los roles
        /// </summary>
        /// <returns></returns>
        public Task<List<Role>> GetAllAsync() => context.Roles.ToListAsync();

        /// <summary>
        /// Metodo para obtener todos un role por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Role?> GetByIdAsync(int id) => context.Roles.FindAsync(id).AsTask();

        /// <summary>
        /// Metodo para agregar roles
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public Task AddAsync(Role role) => context.Roles.AddAsync(role).AsTask();

        /// <summary>
        /// Metodo para actualizar roles
        /// </summary>
        /// <param name="role"></param>
        public void Update(Role role) => context.Roles.Update(role);

        /// <summary>
        /// Metodo para eliminar roles
        /// </summary>
        /// <param name="role"></param>
        public void Delete(Role role) => context.Roles.Remove(role);
    }
}
