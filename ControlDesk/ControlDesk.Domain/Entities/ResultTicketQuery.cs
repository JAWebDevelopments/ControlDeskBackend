using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDesk.Domain.Entities
{
    public class ResultTicketQuery
    {
        public int TicketID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? IsOpen { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? RoleName { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
