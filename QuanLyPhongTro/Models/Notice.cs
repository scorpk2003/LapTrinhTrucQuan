using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.src.Models;

public partial class Notice
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Status { get; set; }

    public Guid? Idreport { get; set; }

    public virtual Report? IdreportNavigation { get; set; }
}
