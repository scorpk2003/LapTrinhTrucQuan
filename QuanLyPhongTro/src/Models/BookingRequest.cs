using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.Entities;

public partial class BookingRequest
{
    public Guid Id { get; set; }

    public Guid IdRenter { get; set; }

    public Guid IdRoom { get; set; }

    public DateTime DesiredStartDate { get; set; }

    public int DesiredDurationMonths { get; set; }

    public string? Note { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public virtual Person IdRenterNavigation { get; set; } = null!;

    public virtual Room IdRoomNavigation { get; set; } = null!;
}
