namespace ControlDesk.Application.DTOs
{
    public class CreateTicketDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int State { get; set; }
        public required int Priority { get; set; }
        public required DateTime CreatedDate { get; set; }
        public required int UserIdCreated { get; set; }
        public required int UserIdAssigned { get; set; }
    }
}
