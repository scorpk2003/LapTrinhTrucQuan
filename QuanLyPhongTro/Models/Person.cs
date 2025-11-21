using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.src.Models;

public partial class Person
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Role { get; set; }

    public Guid? IdDetail { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<BookingRequest> BookingRequests { get; set; } = new List<BookingRequest>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual PersonDetail? IdDetailNavigation { get; set; }

    public virtual ICollection<ListRoom> ListRooms { get; set; } = new List<ListRoom>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
