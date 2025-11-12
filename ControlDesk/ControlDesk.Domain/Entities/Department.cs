using System;
using System.Collections.Generic;

namespace ControlDesk.Domain.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string DepartmentDescription { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
