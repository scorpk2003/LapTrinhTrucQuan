using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.Entities;

public partial class Service
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Unit { get; set; }

    public decimal? PricePerUnit { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();
}
