using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QuanLyPhongTro.Model
{
   public class Bill
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? IdRoom { get; set; }
        [ForeignKey("IdRoom")]
        public Room Room { get; set; }

        public Guid? IdPerson { get; set; } // người tạo hoặc người thuê
        [ForeignKey("IdPerson")]
        public Person Person { get; set; }

        public decimal TotalMoney { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string Status { get; set; }

        // Chi tiết dịch vụ
        public ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

        // Thanh toán liên quan (nhiều lần thanh toán nếu muốn)
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
