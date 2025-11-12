using ControlDesk.Domain.Entities;

namespace ControlDesk.Domain.Interfaces
{
    public interface ITicketRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Ticket?> GetByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<ResultTicketQuery>> GetAllPagAsync(int pageNumber, int pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        Task AddAsync(Ticket ticket);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticket"></param>
        void Update(Ticket ticket);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticket"></param>
        void Delete(Ticket ticket);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Ticket>> GetAllAsync();
    }
}
