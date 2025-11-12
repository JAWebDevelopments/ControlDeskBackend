
namespace ControlDesk.Domain.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// interface para Obtener un token
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="username"></param>
        /// <param name="validTime"></param>
        /// <returns></returns>
        string GenerateToken(DateTime currentDate, string username, TimeSpan validTime);
    }
}
