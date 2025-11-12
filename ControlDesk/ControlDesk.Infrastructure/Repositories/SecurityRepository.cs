using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;
using ControlDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlDesk.Infrastructure.Repositories
{
    public class SecurityRepository(ControlDeskContext context) : ISecurityRepository
    {
        /// <summary>
        /// Metodo para obtener  lista de usuarios
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetAllAsync() => context.Users.ToListAsync();

        /// <summary>
        /// Metodo para hacer login con usuario y contraeña
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Task<User?> GetLoginAsync(string userName, string pass) => context.Users.FindAsync(userName, pass).AsTask();
    }
}
