using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.Model
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(20)]
        public string Role { get; set; }

        public Guid? IdDetail { get; set; }

        [ForeignKey("IdDetail")]
        public PersonDetailcs PersonDetail { get; set; }
    }
}
