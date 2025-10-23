using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.Model
{
    public class Service
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string Name { get; set; }   // e.g. Electricity, Water, Wifi

        [MaxLength(50)]
        public string Unit { get; set; }   // e.g. kWh, m3, month

        public decimal PricePerUnit { get; set; }

        // Navigation
        public ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();
    }
}
