using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.Model
{
    public class PersonDetailcs
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string CCCD { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        public byte[] Avatar { get; set; }

        // Navigation property ngược lại
        public Person Person { get; set; }
    }
}
