using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyPhongTro.src.Models;

[Table("Room")]
public partial class Room
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public Guid? IdOwner { get; set; }

    public Guid? IdListRoom { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Area { get; set; }

    [InverseProperty("IdRoomNavigation")]
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    [InverseProperty("IdRoomNavigation")]
    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    [ForeignKey("IdOwner")]
    [InverseProperty("Rooms")]
    public virtual Person? IdOwnerNavigation { get; set; }

    [ForeignKey("IdListRoom")]
    public virtual ListRoom? ListRooms { get; set; }

    [InverseProperty("IdRoomNavigation")]
    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [InverseProperty("IdRoomNavigation")]
    public virtual ICollection<RoomImage> RoomImages { get; set; } = new List<RoomImage>();
}
