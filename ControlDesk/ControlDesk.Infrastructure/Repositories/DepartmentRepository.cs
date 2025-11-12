using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;
using ControlDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlDesk.Infrastructure.Repositories
{
    public class DepartmentRepository(ControlDeskContext context) : IDepartmentRepository
    {
        public Task<List<Department>> GetAllAsync() => context.Departments.ToListAsync();
        public Task<Department?> GetByIdAsync(int id) => context.Departments.FindAsync(id).AsTask();
        public Task AddAsync(Department department) => context.Departments.AddAsync(department).AsTask();
        public void Update(Department department) => context.Departments.Update(department);
        public void Delete(Department department) => context.Departments.Remove(department);
    }
}
