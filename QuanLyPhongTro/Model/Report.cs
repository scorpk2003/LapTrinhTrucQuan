using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyPhongTro.Model
{
    public class Report
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Người báo cáo (Người thuê)
        public Guid? IdReporter { get; set; }
        [ForeignKey("IdReporter")]
        public Person Reporter { get; set; }

        // (Tùy chọn) Phòng liên quan
        public Guid? IdRoom { get; set; }
        [ForeignKey("IdRoom")]
        public Room Room { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; // "Pending", "Resolved"
    }
}