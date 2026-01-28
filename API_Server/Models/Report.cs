using System;
using System.Collections.Generic;

namespace API_Server.src.Models;

public partial class Report
{
    public Guid Id { get; set; }

    public Guid? IdReporter { get; set; }

    public Guid? IdRoom { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? Status { get; set; }

    public virtual Person? IdReporterNavigation { get; set; }

    public virtual Room? IdRoomNavigation { get; set; }

    public virtual Notice? Notice { get; set; }
}
