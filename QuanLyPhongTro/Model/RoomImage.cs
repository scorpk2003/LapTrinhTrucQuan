using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.Model
{
    public class RoomImage
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? IdRoom { get; set; }
        [ForeignKey("IdRoom")]
        public Room Room { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }
    }
}
