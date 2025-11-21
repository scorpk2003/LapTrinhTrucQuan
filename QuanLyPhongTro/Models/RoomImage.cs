using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.src.Models;

public partial class RoomImage
{
    public Guid Id { get; set; }

    public Guid? IdRoom { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Room? IdRoomNavigation { get; set; }
}
