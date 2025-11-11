using ControlDesk.Domain.Entities;

namespace ControlDesk.Domain.Interfaces
{
    public interface ISecurityRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetLoginAsync(string userName, string pass);
    }
}
