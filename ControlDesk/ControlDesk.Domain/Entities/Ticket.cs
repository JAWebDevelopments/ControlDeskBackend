using System;
using System.Collections.Generic;

namespace ControlDesk.Domain.Entities;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int State { get; set; }

    public int Priority { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UserIdCreated { get; set; }

    public int UserIdAssigned { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User UserIdCreatedNavigation { get; set; } = null!;
}
