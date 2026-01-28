using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.src.Models;

public partial class ListRoom
{
    public Guid Id { get; set; }

    public Guid IdOwner { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Person IdOwnerNavigation { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
