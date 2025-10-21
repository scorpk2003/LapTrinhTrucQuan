using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.Model
{
    public class Contract
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? IdRoom { get; set; }
        [ForeignKey("IdRoom")]
        public Room Room { get; set; }

        public Guid? IdRenter { get; set; }
        [ForeignKey("IdRenter")]
        public Person Renter { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal Deposit { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }  // Active, Expired, Cancelled, Pending

        public string Note { get; set; }
    }
}
