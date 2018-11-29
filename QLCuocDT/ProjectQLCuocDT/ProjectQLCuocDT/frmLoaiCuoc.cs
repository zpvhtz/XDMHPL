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
        private LoaiCuocBUS loaicuocbus = new LoaiCuocBUS();

        public frmLoaiCuoc()
        {
            InitializeComponent();
        }

        private void frmLoaiCuoc_Load(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void dgvLoaiCuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSTT.Text = dgvLoaiCuoc.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMaLoaiCuoc.Text = dgvLoaiCuoc.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpTGBD.Value = DateTime.Parse(dgvLoaiCuoc.Rows[e.RowIndex].Cells[2].Value.ToString());
                dtpTGKT.Value = DateTime.Parse(dgvLoaiCuoc.Rows[e.RowIndex].Cells[3].Value.ToString());
                dtpNgayApDung.Value = DateTime.Parse(dgvLoaiCuoc.Rows[e.RowIndex].Cells[4].Value.ToString());
                numericGiaCuoc.Value = decimal.Parse(dgvLoaiCuoc.Rows[e.RowIndex].Cells[5].Value.ToString());
                cbbTinhTrang.SelectedItem = dgvLoaiCuoc.Rows[e.RowIndex].Cells[6].Value.ToString();

                txtMaLoaiCuoc.Enabled = false;
                cbbTinhTrang.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(CheckNullOrEmpty())
            {
                int stt = int.Parse(txtSTT.Text);
                string maloaicuoc = txtMaLoaiCuoc.Text;
                TimeSpan tgbd = TimeSpan.Parse(dtpTGKT.Value.ToString("HH:mm:ss"));
                TimeSpan tgkt = TimeSpan.Parse(dtpTGKT.Value.ToString("HH:mm:ss"));
                DateTime ngayapdung = dtpNgayApDung.Value;
                decimal giacuoc = decimal.Parse(numericGiaCuoc.Value.ToString());
                MessageBox.Show(loaicuocbus.AddLoaiCuoc(stt, maloaicuoc, tgbd, tgkt, ngayapdung, giacuoc));
                RefreshPage();
            }
        }

        private void chkThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            GetThoiGian();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RefreshPage();
            txtSTT.Text = loaicuocbus.GetSTT().ToString();
            txtMaLoaiCuoc.Clear();
            GetThoiGian();
            dtpNgayApDung.Value = DateTime.Now;
            cbbTinhTrang.SelectedItem = "Không khoá";

            txtMaLoaiCuoc.Enabled = true;
            cbbTinhTrang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maloaicuoc = txtMaLoaiCuoc.Text;
            TimeSpan tgbd = TimeSpan.Parse(dtpTGBD.Value.ToString("HH:mm:ss"));
            TimeSpan tgkt = TimeSpan.Parse(dtpTGKT.Value.ToString("HH:mm:ss"));
            DateTime ngayapdung = dtpNgayApDung.Value;
            decimal giacuoc = decimal.Parse(numericGiaCuoc.Value.ToString());
            bool tinhtrang = cbbTinhTrang.SelectedItem.ToString() == "Không khoá" ? true : false;
            MessageBox.Show(loaicuocbus.EditLoaiCuoc(maloaicuoc, tgbd, tgkt, ngayapdung, giacuoc, tinhtrang));
            RefreshPage();
        }

        private void GetFirstValueDataGridView()
        {
            txtSTT.Text = dgvLoaiCuoc.Rows[0].Cells[0].Value.ToString();
            txtMaLoaiCuoc.Text = dgvLoaiCuoc.Rows[0].Cells[1].Value.ToString();
            dtpTGBD.Value = DateTime.Parse(dgvLoaiCuoc.Rows[0].Cells[2].Value.ToString());
            dtpTGKT.Value = DateTime.Parse(dgvLoaiCuoc.Rows[0].Cells[3].Value.ToString());
            dtpNgayApDung.Value = DateTime.Parse(dgvLoaiCuoc.Rows[0].Cells[4].Value.ToString());
            numericGiaCuoc.Value = decimal.Parse(dgvLoaiCuoc.Rows[0].Cells[5].Value.ToString());
            cbbTinhTrang.SelectedItem = dgvLoaiCuoc.Rows[0].Cells[6].Value.ToString();

            txtMaLoaiCuoc.Enabled = false;
            cbbTinhTrang.Enabled = true;
        }

        private void GetThoiGian()
        {
            if (chkThoiGian.Checked == true)
            {
                dtpTGBD.Value = DateTime.Parse("07:00:00");
                dtpTGKT.Value = DateTime.Parse("22:59:59");
            }
            else
            {
                dtpTGBD.Value = DateTime.Parse("23:00:00");
                dtpTGKT.Value = DateTime.Parse("06:59:59");
            }
        }

        private bool CheckNullOrEmpty()
        {
            if (txtMaLoaiCuoc.Text == "")
            {
                MessageBox.Show("Cần điền vào mã loại cước");
                return false;
            }
            if (dtpNgayApDung.Value < DateTime.Now)
            {
                MessageBox.Show("Thời gian áp dụng phải sau thời điểm hiện tại");
                return false;
            }
            if(numericGiaCuoc.Value < 0)
            {
                MessageBox.Show("Giá cước thấp nhất phải là 0");
                return false;
            }
            return true;
        }

        private void RefreshPage()
        {
            //dgvLoaiCuoc.DataSource = null;
            //dgvLoaiCuoc.Rows.Clear();
            dgvLoaiCuoc.DataSource = loaicuocbus.GetLoaiCuocs();
            GetFirstValueDataGridView();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "")
            {
                MessageBox.Show("Nhập vào thông tin cần tìm kiếm");
            }
            else
            {
                string search = txtTimKiem.Text;
                dgvLoaiCuoc.DataSource = loaicuocbus.SearchLoaiCuoc(search);
                GetFirstValueDataGridView();
            }
        }
    }
}
