using System;
using System.Collections.Generic;

namespace TMS.TMSService.Domain.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int UserId { get; set; }

    public int TaskItemId { get; set; }

    public virtual TaskItem TaskItem { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
