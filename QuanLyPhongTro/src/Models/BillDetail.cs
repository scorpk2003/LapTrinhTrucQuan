using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyPhongTro.src.Models;

[Table("BillDetail")]
public partial class BillDetail
{
    [Key]
    public Guid Id { get; set; }

    public Guid? IdBill { get; set; }

    public Guid? IdService { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Total { get; set; }

    public decimal? Water { get; set; }

    public decimal? Electricity { get; set; }

    [ForeignKey("IdBill")]
    [InverseProperty("BillDetails")]
    public virtual Bill? IdBillNavigation { get; set; }

    [ForeignKey("IdService")]
    [InverseProperty("BillDetails")]
    public virtual Service? IdServiceNavigation { get; set; }
}
