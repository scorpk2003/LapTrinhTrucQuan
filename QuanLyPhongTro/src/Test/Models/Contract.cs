using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyPhongTro.src.Test.Models;

[Table("Contract")]
public partial class Contract
{
    [Key]
    public Guid Id { get; set; }

    public Guid? IdRoom { get; set; }

    public Guid? IdRenter { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Deposit { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    [ForeignKey("IdRenter")]
    [InverseProperty("Contracts")]
    public virtual Person? IdRenterNavigation { get; set; }

    [ForeignKey("IdRoom")]
    [InverseProperty("Contracts")]
    public virtual Room? IdRoomNavigation { get; set; }
}
