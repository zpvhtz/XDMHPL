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
    public partial class frmHoaDonDK : Form
    {
        private HoaDonDKBUS hoadondkbus = new HoaDonDKBUS();
        private SimBUS simbus = new SimBUS();
        private KhachHangBUS khachhangbus = new KhachHangBUS();

        public frmHoaDonDK()
        {
            InitializeComponent();
        }

        #region methods
        private void GetFirstValueDataGridView()
        {
            SetEnabled(false);
            cbSoSim.DropDownStyle = ComboBoxStyle.DropDown;
            txtMaHD.Text = dgvHoaDon.Rows[0].Cells[0].Value.ToString();
            txtTenKhachHang.Text = dgvHoaDon.Rows[0].Cells[1].Value.ToString();
            txtCMND.Text = dgvHoaDon.Rows[0].Cells[2].Value.ToString();
            cbSoSim.Text = simbus.GetSimByMaSim(int.Parse(dgvHoaDon.Rows[0].Cells[6].Value.ToString())).SoSim;
            dtpNgayDangKy.Value = DateTime.Parse(dgvHoaDon.Rows[0].Cells[3].Value.ToString());
            numericChiPhi.Value = int.Parse(dgvHoaDon.Rows[0].Cells[4].Value.ToString());
            txtDiaChi.Text = dgvHoaDon.Rows[0].Cells[7].Value.ToString();
            txtMaKH.Text = dgvHoaDon.Rows[0].Cells[5].Value.ToString();
        }

        private void RefreshPage()
        {
            dgvHoaDon.DataSource = hoadondkbus.GetHoaDonDKs();
            GetFirstValueDataGridView();
        }

        private bool CheckNullOrEmpty()
        {
            if (txtTenKhachHang.Text == "")
            {
                MessageBox.Show("Cần điền vào tên khách hàng");
                return false;
            }
            if (txtCMND.Text == "")
            {
                MessageBox.Show("Cần điền vào CMND");
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Cần điền vào địa chỉ");
                return false;
            }
            if (numericChiPhi.Value < 0)
            {
                MessageBox.Show("Phí hòa mạng thấp nhất phải là 0");
                return false;
            }
            if (cbSoSim.Text == "-- Chọn số --")
            {
                MessageBox.Show("Cần chọn số sim");
                return false;
            }
            return true;
        }

        public void SetEnabled(bool status)
        {
            txtTenKhachHang.Enabled = status;
            txtCMND.Enabled = status;
            txtDiaChi.Enabled = status;
            dtpNgayDangKy.Enabled = status;
            numericChiPhi.Enabled = status;
            cbSoSim.Enabled = status;
            txtEmail.Enabled = status;
            if (status == false)
                ckbKHCu.Enabled = true;
            else
                ckbKHCu.Enabled = false;
        }
        #endregion

        #region events
        private void frmHoaDonDK_Load(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckNullOrEmpty())
            {
                if (khachhangbus.CheckExistKH(int.Parse(txtMaKH.Text)) || ckbKHCu.Checked == true)
                {
                    int makh = int.Parse(txtMaKH.Text);
                    if (ckbKHCu.Checked == false)
                    {
                        //thêm khách hàng
                        string tenkh = txtTenKhachHang.Text;
                        string cmnd = txtCMND.Text;
                        string diachi = txtDiaChi.Text;
                        string item = khachhangbus.AddKhachHang(makh, tenkh, cmnd, diachi);
                    }

                    //thêm hóa đơn
                    int mahd = int.Parse(txtMaHD.Text);
                    int masim = simbus.GetMaSimBySoSim(cbSoSim.Text);
                    DateTime ngaydk = dtpNgayDangKy.Value;
                    decimal chiphi = decimal.Parse(numericChiPhi.Value.ToString());
                    MessageBox.Show(hoadondkbus.AddHoaDon(mahd, masim, ngaydk, chiphi, makh));

                    simbus.EditStatusSim(masim, true);
                    RefreshPage();
                }
                else
                {
                    MessageBox.Show("Hãy bấm thêm mới hoặc chọn khách hàng cũ để thêm");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            SetEnabled(true);
            txtMaHD.Text = hoadondkbus.GetMaHoaDon().ToString();
            txtTenKhachHang.Clear();
            txtCMND.Clear();
            txtDiaChi.Clear();
            dtpNgayDangKy.Value = DateTime.Now;
            numericChiPhi.Value = 50000;
            cbSoSim.DataSource = simbus.GetListSimByStatus(false);
            cbSoSim.DisplayMember = "SoSim";
            cbSoSim.DropDownStyle = ComboBoxStyle.DropDownList;
            txtMaKH.Text = khachhangbus.GetMaKH().ToString();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetEnabled(false);
                ckbKHCu.Checked = false;
                txtMaHD.Text = dgvHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenKhachHang.Text = dgvHoaDon.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCMND.Text = dgvHoaDon.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbSoSim.Text = simbus.GetSimByMaSim(int.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[6].Value.ToString())).SoSim;
                dtpNgayDangKy.Value = DateTime.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[3].Value.ToString());
                numericChiPhi.Value = int.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtDiaChi.Text = dgvHoaDon.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtMaKH.Text = dgvHoaDon.Rows[e.RowIndex].Cells[5].Value.ToString();
                cbSoSim.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbKHCu.Checked == true)
            {
                cbSoSim.Enabled = true;
                cbSoSim.DataSource = simbus.GetListSimByStatus(false);
                cbSoSim.DisplayMember = "SoSim";
                cbSoSim.DropDownStyle = ComboBoxStyle.DropDownList;
                txtMaHD.Text = hoadondkbus.GetMaHoaDon().ToString();
            }
            else
                cbSoSim.Enabled = false;
        }
        #endregion
    }
}
