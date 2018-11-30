using Services.BUS;
using Services.Database;
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
            if(dgvHoaDonThanhToan.Rows.Count > 0)
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

        private async void btnGuiEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show(await hoadonthanhtoanbus.ActivationMail());
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if(cbbFilter.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mục cần lọc");
            }
            else
            {
                string filteritem = "";
                string filter = "null";

                switch (cbbFilter.SelectedItem.ToString())
                {
                    case "Thành tiền":
                        filteritem = cbbFilter.SelectedItem.ToString();
                        decimal thanhtienmin = numericFilterThanhTienMin.Value;
                        decimal thanhtienmax = numericFilterThanhTienMax.Value;
                        dgvHoaDonThanhToan.DataSource = hoadonthanhtoanbus.FilterHoaDonThanhToan(filteritem, filter, null, null, thanhtienmin, thanhtienmax);
                        break;
                    case "Ngày tạo":
                        filteritem = cbbFilter.SelectedItem.ToString();
                        DateTime ngaybdtao = dtpFilterNgayBDTao.Value;
                        DateTime ngaykttao = dtpFilterNgayKTTao.Value;
                        dgvHoaDonThanhToan.DataSource = hoadonthanhtoanbus.FilterHoaDonThanhToan(filteritem, filter, ngaybdtao, ngaykttao, 0, 0);
                        break;
                    case "Thanh toán":
                        if (cbbFilterThanhToan.SelectedItem == null)
                        {
                            MessageBox.Show("Vui lòng chọn tình trạng thanh toán để lọc");
                            return;
                        }
                        else
                        {
                            filteritem = cbbFilter.SelectedItem.ToString();
                            filter = cbbFilterThanhToan.SelectedItem.ToString();
                            dgvHoaDonThanhToan.DataSource = hoadonthanhtoanbus.FilterHoaDonThanhToan(filteritem, filter, null, null, 0, 0);
                        }
                        break;
                    case "Tình trạng":
                        if (cbbTinhTrang.SelectedItem == null)
                        {
                            MessageBox.Show("Vui lòng chọn tình trạng để lọc");
                            return;
                        }
                        else
                        {
                            filteritem = cbbFilter.SelectedItem.ToString();
                            filter = cbbTinhTrang.SelectedItem.ToString();
                            dgvHoaDonThanhToan.DataSource = hoadonthanhtoanbus.FilterHoaDonThanhToan(filteritem, filter, null, null, 0, 0);
                        }
                        break;
                }

                if(dgvHoaDonThanhToan.Rows.Count > 0)
                {
                    GetFirstValueDataGridView();
                }
            }
        }

        private void cbbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbbFilter.SelectedItem.ToString())
            {
                case "Thành tiền":
                    dtpFilterNgayBDTao.Visible = false;
                    dtpFilterNgayKTTao.Visible = false;
                    numericFilterThanhTienMin.Visible = true;
                    numericFilterThanhTienMax.Visible = true;
                    cbbFilterThanhToan.Visible = false;
                    cbbFilterTinhTrang.Visible = false;
                    break;
                case "Ngày tạo":
                    dtpFilterNgayBDTao.Visible = true;
                    dtpFilterNgayKTTao.Visible = true;
                    numericFilterThanhTienMin.Visible = false;
                    numericFilterThanhTienMax.Visible = false;
                    cbbFilterThanhToan.Visible = false;
                    cbbFilterTinhTrang.Visible = false;
                    break;
                case "Thanh toán":
                    dtpFilterNgayBDTao.Visible = false;
                    dtpFilterNgayKTTao.Visible = false;
                    numericFilterThanhTienMin.Visible = false;
                    numericFilterThanhTienMax.Visible = false;
                    cbbFilterThanhToan.Visible = true;
                    cbbFilterTinhTrang.Visible = false;
                    break;
                case "Tình trạng":
                    dtpFilterNgayBDTao.Visible = false;
                    dtpFilterNgayKTTao.Visible = false;
                    numericFilterThanhTienMin.Visible = false;
                    numericFilterThanhTienMax.Visible = false;
                    cbbFilterThanhToan.Visible = false;
                    cbbFilterTinhTrang.Visible = true;
                    break;
            }
        }
    }
}
