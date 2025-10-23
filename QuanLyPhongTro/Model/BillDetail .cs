using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.Model
{
    public class BillDetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? IdBill { get; set; }
        [ForeignKey("IdBill")]
        public Bill Bill { get; set; }

        public Guid? IdService { get; set; }
        [ForeignKey("IdService")]
        public Service Service { get; set; }

        public decimal Quantity { get; set; }

        public decimal Total { get; set; }
    }
}
