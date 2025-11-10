using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyPhongTro.Model
{
    public class BookingRequest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IdRenter { get; set; } // Người yêu cầu
        [ForeignKey("IdRenter")]
        public Person Renter { get; set; }

        public Guid IdRoom { get; set; } // Phòng muốn thuê
        [ForeignKey("IdRoom")]
        public Room Room { get; set; }

        public DateTime DesiredStartDate { get; set; } // Ngày muốn bắt đầu
        public int DesiredDurationMonths { get; set; } // Thời hạn (ví dụ: 6, 12)

        public string Note { get; set; } // Ghi chú của người thuê

        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; // "Pending", "Approved", "Rejected"

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}