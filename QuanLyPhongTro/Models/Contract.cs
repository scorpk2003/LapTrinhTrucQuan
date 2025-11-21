using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.src.Models;

public partial class Contract
{
    public Guid Id { get; set; }

    public Guid? IdRoom { get; set; }

    public Guid? IdRenter { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Deposit { get; set; }

    public string? Status { get; set; }

    public virtual Person? IdRenterNavigation { get; set; }

    public virtual Room? IdRoomNavigation { get; set; }
}
