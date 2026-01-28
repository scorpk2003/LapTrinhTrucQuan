using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyPhongTro.src.Test.Models;

[Table("Notice")]
public partial class Notice
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(200)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Status { get; set; } = "Chua d?c";

    [Column("IDReport")]
    public Guid? Idreport { get; set; }

    [ForeignKey("Idreport")]
    [InverseProperty("Notice")]
    public virtual Report? IdreportNavigation { get; set; }
}
