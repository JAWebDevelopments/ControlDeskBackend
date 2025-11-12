using ControlDesk.Domain.Entities;

namespace ControlDesk.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllPagAsync(int pageNumber, int pageSize);
        Task AddAsync(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
        Task<List<Ticket>> GetAllAsync();
    }
}
