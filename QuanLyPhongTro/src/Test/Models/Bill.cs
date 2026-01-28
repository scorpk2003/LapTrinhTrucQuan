using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyPhongTro.src.Test.Models;

[Table("Bill")]
public partial class Bill
{
    [Key]
    public Guid Id { get; set; }

    public Guid? IdRoom { get; set; }

    public Guid? IdPerson { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalMoney { get; set; }

    public string Status { get; set; } = "";

    [Column(TypeName = "datetime")]
    public DateTime? PaymentDate { get; set; }

    [InverseProperty("IdBillNavigation")]
    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

    [ForeignKey("IdPerson")]
    [InverseProperty("Bills")]
    public virtual Person? IdPersonNavigation { get; set; }

    [ForeignKey("IdRoom")]
    [InverseProperty("Bills")]
    public virtual Room? IdRoomNavigation { get; set; }

    [InverseProperty("IdPaymentNavigation")]
    public virtual Payment? Payment { get; set; }
}
