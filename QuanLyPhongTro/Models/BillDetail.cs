using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.src.Models;

public partial class BillDetail
{
    public Guid Id { get; set; }

    public Guid? IdBill { get; set; }

    public Guid? IdService { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Total { get; set; }

    public decimal? Electricity { get; set; }

    public decimal? Water { get; set; }

    public virtual Bill? IdBillNavigation { get; set; }

    public virtual Service? IdServiceNavigation { get; set; }
}
