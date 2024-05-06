using System;
using System.Collections.Generic;

namespace TMS.TMSService.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}
