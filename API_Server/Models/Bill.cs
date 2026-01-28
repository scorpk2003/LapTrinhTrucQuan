using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Server.src.Models;


public partial class Bill
{
    public Guid Id { get; set; }

    public Guid? IdRoom { get; set; }

    public Guid? IdPerson { get; set; }

    public decimal? TotalMoney { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual BillDetail? BillDetail { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }

    public virtual Room? IdRoomNavigation { get; set; }

    public virtual Payment? Payment { get; set; }
}
