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
        Task<Department?> GetByIdAsync(int id);
        Task<List<Department>> GetAllAsync();
        Task AddAsync(Department department);
        void Update(Department department);
        void Delete(Department department);
    }
}
