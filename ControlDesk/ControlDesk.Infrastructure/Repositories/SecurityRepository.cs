using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;
using ControlDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlDesk.Infrastructure.Repositories
{
    public class SecurityRepository(ControlDeskContext context) : ISecurityRepository
    {
        public Task<List<User>> GetAllAsync() => context.Users.ToListAsync();
        public Task<User?> GetLoginAsync(string userName, string pass) => context.Users.FindAsync(userName, pass).AsTask();
    }
}
