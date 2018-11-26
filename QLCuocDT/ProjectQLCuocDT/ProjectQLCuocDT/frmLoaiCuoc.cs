using Services.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQLCuocDT
{
    public partial class frmLoaiCuoc : Form
    {
        LoaiCuocBUS loaicuocbus = new LoaiCuocBUS();

        public frmLoaiCuoc()
        {
            InitializeComponent();
        }

        private void frmLoaiCuoc_Load(object sender, EventArgs e)
        {
            dgvLoaiCuoc.DataSource = loaicuocbus.GetLoaiCuocs();
        }
    }
}
