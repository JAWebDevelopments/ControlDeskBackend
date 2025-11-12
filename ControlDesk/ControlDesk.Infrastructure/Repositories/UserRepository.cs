using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;
using ControlDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlDesk.Infrastructure.Repositories
{
    public class UserRepository(ControlDeskContext context) : IUserRepository
    {
        public Task<List<User>> GetAllAsync() => context.Users.ToListAsync();
        public Task<User?> GetByIdAsync(int id) => context.Users.FindAsync(id).AsTask();
        public Task AddAsync(User user) => context.Users.AddAsync(user).AsTask();
        public void Update(User user) => context.Users.Update(user);
        public void Delete(User user) => context.Users.Remove(user);
    }
}
