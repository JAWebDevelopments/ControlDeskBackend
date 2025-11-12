using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;
using ControlDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlDesk.Infrastructure.Repositories
{
    public class UserRepository(ControlDeskContext context) : IUserRepository
    {
        /// <summary>
        /// Metodo para obtener todos los usuarios
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetAllAsync() => context.Users.ToListAsync();

        /// <summary>
        /// Metodo para obtener usuarios por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User?> GetByIdAsync(int id) => context.Users.FindAsync(id).AsTask();

        /// <summary>
        /// Metodo para agregar un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task AddAsync(User user) => context.Users.AddAsync(user).AsTask();

        /// <summary>
        /// Metodo para modificar un usuario
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user) => context.Users.Update(user);

        /// <summary>
        /// Metodo para eliminar un usuario
        /// </summary>
        /// <param name="user"></param>
        public void Delete(User user) => context.Users.Remove(user);
    }
}
