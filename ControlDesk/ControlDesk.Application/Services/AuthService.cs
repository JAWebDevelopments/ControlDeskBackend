using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class AuthService(IAuthService authService)
    {
        /// <summary>
        /// Servicio para obtener el token
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="username"></param>
        /// <param name="validTime"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
        public string GenerateToken(DateTime currentDate, string username, TimeSpan validTime)
        {
			try
			{
                return authService.GenerateToken(currentDate, username, validTime);

            }
			catch (GenericException ex)
			{

				throw new GenericException("Exception: ", ex);
			}
        }
    }
}
