using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.src.Models;

public partial class Expense
{
    public Guid Id { get; set; }

    public Guid IdOwner { get; set; }

    public Guid? IdRoom { get; set; }

    public string Category { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime DateIncurred { get; set; }

    public string Description { get; set; } = null!;

    public virtual Person IdOwnerNavigation { get; set; } = null!;

    public virtual Room? IdRoomNavigation { get; set; }
}
