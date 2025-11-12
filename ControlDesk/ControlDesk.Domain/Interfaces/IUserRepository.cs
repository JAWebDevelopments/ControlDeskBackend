using ControlDesk.Domain.Entities;

namespace ControlDesk.Domain.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// obtiene los usuarios por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User?> GetByIdAsync(int id);

        /// <summary>
        /// obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllAsync();

        /// <summary>
        /// agrega un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddAsync(User user);

        /// <summary>
        /// actualiza datos de un usuario
        /// </summary>
        /// <param name="user"></param>
        void Update(User user);

        /// <summary>
        /// elimina un usuario
        /// </summary>
        /// <param name="user"></param>
        void Delete(User user);
    }
}
