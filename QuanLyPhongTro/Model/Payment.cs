using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.Model
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? IdBill { get; set; }
        [ForeignKey("IdBill")]
        public Bill Bill { get; set; }

        [MaxLength(50)]
        public string PaymentMethod { get; set; }  // Cash, Bank, MoMo...

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public string Note { get; set; }
    }
}
