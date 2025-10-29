using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.src.Components
{
    public partial class RoomDetailControl : UserControl
    {
        public RoomDetailControl()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RoomDetail_Load(object sender, EventArgs e)
        {
            //role = renter -> hide sign button
            //role = owner -> show sign button
            // Load Person avatar here
            /*
             * avatar != null ? avatar : default avatar
             */
        }
    }
}
