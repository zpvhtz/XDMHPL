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
    public partial class frmHoaDonThanhToan : Form
    {
        private HoaDonThanhToanBUS hoadonthanhtoanbus = new HoaDonThanhToanBUS();
        public frmHoaDonThanhToan()
        {
            InitializeComponent();
        }

        private void frmHoaDonThanhToan_Load(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void RefreshPage()
        {
            //dgvLoaiCuoc.DataSource = null;
            //dgvLoaiCuoc.Rows.Clear();
            dgvHoaDonThanhToan.DataSource = hoadonthanhtoanbus.GetHoaDonThanhToans();
            GetFirstValueDataGridView();
        }

        private void GetFirstValueDataGridView()
        {
            txtMaHoaDon.Text = dgvHoaDonThanhToan.Rows[0].Cells[0].Value.ToString();
            txtTenKhachHang.Text = dgvHoaDonThanhToan.Rows[0].Cells[1].Value.ToString();
            txtSoSim.Text = dgvHoaDonThanhToan.Rows[0].Cells[2].Value.ToString();
            numericCuocThueBao.Value = decimal.Parse(dgvHoaDonThanhToan.Rows[0].Cells[3].Value.ToString());
            dtpNgayTao.Value = DateTime.Parse(dgvHoaDonThanhToan.Rows[0].Cells[4].Value.ToString());
            cbbThanhToan.SelectedItem = dgvHoaDonThanhToan.Rows[0].Cells[5].Value.ToString();
            numericThanhTien.Value = decimal.Parse(dgvHoaDonThanhToan.Rows[0].Cells[6].Value.ToString());
            cbbTinhTrang.SelectedItem = dgvHoaDonThanhToan.Rows[0].Cells[7].Value.ToString();
        }

        private void dgvHoaDonThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaHoaDon.Text = dgvHoaDonThanhToan.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenKhachHang.Text = dgvHoaDonThanhToan.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoSim.Text = dgvHoaDonThanhToan.Rows[e.RowIndex].Cells[2].Value.ToString();
                numericCuocThueBao.Value = decimal.Parse(dgvHoaDonThanhToan.Rows[e.RowIndex].Cells[3].Value.ToString());
                dtpNgayTao.Value = DateTime.Parse(dgvHoaDonThanhToan.Rows[e.RowIndex].Cells[4].Value.ToString());
                cbbThanhToan.SelectedItem = dgvHoaDonThanhToan.Rows[e.RowIndex].Cells[5].Value.ToString();
                numericThanhTien.Value = decimal.Parse(dgvHoaDonThanhToan.Rows[e.RowIndex].Cells[6].Value.ToString());
                cbbTinhTrang.SelectedItem = dgvHoaDonThanhToan.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string search = txtTimKiem.Text;
            dgvHoaDonThanhToan.DataSource = hoadonthanhtoanbus.SearchHoaDonThanhToan(search);
            GetFirstValueDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mahd = txtMaHoaDon.Text;
            bool thanhtoan = cbbThanhToan.SelectedItem.ToString() == "Đã thanh toán" ? true : false;
            bool tinhtrang = cbbTinhTrang.SelectedItem.ToString() == "Không khoá" ? true : false;
            MessageBox.Show(hoadonthanhtoanbus.EditHoaDonThanhToan(mahd, thanhtoan, tinhtrang));
            RefreshPage();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }
    }
}
