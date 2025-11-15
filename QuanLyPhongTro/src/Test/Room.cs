using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.Model
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        public Guid? IdOwner { get; set; }
        [ForeignKey("IdOwner")]
        public Person Owner { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
