using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class SecurityService(ISecurityRepository repository)
    {
        public async Task<List<User>> GetAllAsync() => await repository.GetAllAsync();
    }
}
