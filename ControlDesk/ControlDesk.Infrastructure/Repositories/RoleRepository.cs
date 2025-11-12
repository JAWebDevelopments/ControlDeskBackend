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
        public Task<List<Role>> GetAllAsync() => context.Roles.ToListAsync();
        public Task<Role?> GetByIdAsync(int id) => context.Roles.FindAsync(id).AsTask();
        public Task AddAsync(Role role) => context.Roles.AddAsync(role).AsTask();
        public void Update(Role role) => context.Roles.Update(role);
        public void Delete(Role role) => context.Roles.Remove(role);
    }
}
