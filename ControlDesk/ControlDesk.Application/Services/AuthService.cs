using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class AuthService(IAuthService authService)
    {
        public string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez)
        {
			try
			{
                return authService.GenerateToken(fechaActual, username, tiempoValidez);

            }
			catch (GenericException ex)
			{

				throw new GenericException("Exception", ex);
			}
        }
    }
}
