
namespace ControlDesk.Domain.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez);
    }
}
