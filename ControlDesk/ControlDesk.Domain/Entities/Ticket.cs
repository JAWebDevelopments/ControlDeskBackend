using System;
using System.Collections.Generic;

namespace ControlDesk.Domain.Entities;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int State { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UserIdCreated { get; set; }

    public int UserIdAssigned { get; set; }

    public int? UserIdUpdate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User UserIdCreatedNavigation { get; set; } = null!;
}
