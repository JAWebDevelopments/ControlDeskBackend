using ControlDesk.Domain.Entities;

namespace ControlDesk.Domain.Interfaces
{
    public interface ISecurityRepository
    {
        /// <summary>
        /// Interface para obtener todos los usuarios
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllAsync();

        /// <summary>
        /// Interface para login por usuario y contraseña
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        Task<User?> GetLoginAsync(string userName, string pass);
    }
}
