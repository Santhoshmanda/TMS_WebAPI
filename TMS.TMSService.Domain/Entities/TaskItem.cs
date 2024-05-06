using System;
using System.Collections.Generic;

namespace TMS.TMSService.Domain.Entities;

public partial class TaskItem
{
    public int TaskItemId { get; set; }

    public string Description { get; set; } = null!;

    public string? TaskStatus { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime DueDate { get; set; }

    public string? Priority { get; set; }

    public int? UserId { get; set; }

    public int ProjectId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Project Project { get; set; } = null!;

    public virtual User? User { get; set; }
}
