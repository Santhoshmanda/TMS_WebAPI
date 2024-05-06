using System;
using System.Collections.Generic;

namespace TMS.TMSService.Domain.Entities;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}
