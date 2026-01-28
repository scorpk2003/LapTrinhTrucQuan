using System;
using System.Collections.Generic;

namespace API_Server.src.Models;

public partial class Room
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? IdOwner { get; set; }

    public decimal? Area { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public Guid? IdListRoom { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<BookingRequest> BookingRequests { get; set; } = new List<BookingRequest>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ListRoom? IdListRoomNavigation { get; set; }

    public virtual Person? IdOwnerNavigation { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<RoomImage> RoomImages { get; set; } = new List<RoomImage>();
}
