using System;
using System.Collections.Generic;

namespace ControlDesk.Domain.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public int TicketId { get; set; }

    public int UserId { get; set; }

    public string CommentText { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
