using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Test.Models
{
    [Table("BookingRequest")]
    public class BookingRequest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IdRenter { get; set; } // Ng??i yêu c?u
        [ForeignKey("IdRenter")]
        public Person Renter { get; set; }

        public Guid IdRoom { get; set; } // Phòng mu?n thuê
        [ForeignKey("IdRoom")]
        public Room Room { get; set; }

        public DateTime DesiredStartDate { get; set; } // Ngày mu?n b?t ??u
        public int DesiredDurationMonths { get; set; } // Th?i h?n (ví d?: 6, 12)

        [StringLength(500)]
        public string? Note { get; set; } // Ghi chú c?a ng??i thuê

        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; // "Pending", "Approved", "Rejected"

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}

