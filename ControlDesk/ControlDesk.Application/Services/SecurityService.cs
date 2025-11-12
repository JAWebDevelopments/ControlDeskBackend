using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class SecurityService(ISecurityRepository repository)
    {
        /// <summary>
        /// servicio para obtener todos los usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllAsync() => await repository.GetAllAsync();
    }
}
