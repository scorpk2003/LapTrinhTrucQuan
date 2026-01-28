using System;
using System.Collections.Generic;

namespace API_Server.src.Models;

public partial class Payment
{
    public Guid IdBill { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Note { get; set; }

    public virtual Bill IdBillNavigation { get; set; } = null!;
}
