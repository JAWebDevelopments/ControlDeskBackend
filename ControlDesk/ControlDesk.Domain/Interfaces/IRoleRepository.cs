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
        Task<Role?> GetByIdAsync(int id);
        Task<List<Role>> GetAllAsync();
        Task AddAsync(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}
