using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Models
{
    [Table("ListRoom")]
    public partial class ListRoom
    {
        public Guid Id { get; set; }

        public Guid IdOwner { get; set; }

        public string Name { get; set; } = "";

        public string Address { get; set; } = "";

        public string Status { get; set; } = "";

        [ForeignKey("IdOwner")]
        public virtual Person? Owner { get; set; }

        [InverseProperty("ListRooms")]
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
