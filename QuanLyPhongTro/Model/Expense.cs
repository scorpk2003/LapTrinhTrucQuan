using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyPhongTro.Model
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IdOwner { get; set; }
        [ForeignKey("IdOwner")]
        public Person Owner { get; set; }

        public Guid? IdRoom { get; set; }
        [ForeignKey("IdRoom")]
        public Room Room { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; } // Ví dụ: "Bảo trì", "Dịch vụ chung", "Marketing"

        [Required]
        public decimal Amount { get; set; } // Số tiền chi

        public DateTime DateIncurred { get; set; } // Ngày chi

        public string Description { get; set; } // Ghi chú 
    }
}