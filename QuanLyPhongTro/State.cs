using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro
{
    internal class State
    {
        // Bill State
        public const string Paid = "Đã Thanh Toán";
        public const string Unpaid = "Chưa Thanh Toán";

        // List Room - Room State
        public const string Empty = "Còn Trống";
        public const string Room_Empty = "Đã Cho Thuê";
        public const string Full = "Đã Đầy";

        // Notice & Report
        public const string Pending = "Đã Gửi";
        public const string Recv = "Đã Nhận";
        public const string Handled = "Đã xử lí";
    }
}
