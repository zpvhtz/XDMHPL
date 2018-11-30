using Services.BUS;
using Services.Database;
using System;
using System.Windows.Forms;

namespace ProjectQLCuocDT
{
    public partial class Frmkhachhang : Form
    {
        private KhachHangBUS bus = new KhachHangBUS();
        public Frmkhachhang()
        {

            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dvgKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKH.Text = dgvKhachhang.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenKH.Text = dgvKhachhang.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCMND.Text = dgvKhachhang.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNgenghiep.Text = dgvKhachhang.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDiachi.Text = dgvKhachhang.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtEmail.Text = dgvKhachhang.Rows[e.RowIndex].Cells[5].Value.ToString();
                cbStatus.Text = dgvKhachhang.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        private void Frmkhachhang_Load(object sender, EventArgs e)
        {
            dgvKhachhang.DataSource = bus.ListKhachhang();
            GetFirstValueDataGridView();
        }
        private void reload()
        {
            dgvKhachhang.DataSource = null;
            dgvKhachhang.Rows.Clear();
            dgvKhachhang.DataSource = bus.ListKhachhang();
            GetFirstValueDataGridView();
        }
        private void GetFirstValueDataGridView()
        {
            txtMaKH.Text = dgvKhachhang.Rows[0].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachhang.Rows[0].Cells[1].Value.ToString();
            txtCMND.Text = dgvKhachhang.Rows[0].Cells[2].Value.ToString();
            txtNgenghiep.Text = dgvKhachhang.Rows[0].Cells[3].Value.ToString();
            txtDiachi.Text = dgvKhachhang.Rows[0].Cells[4].Value.ToString();
            txtEmail.Text = dgvKhachhang.Rows[0].Cells[5].Value.ToString();           
            cbStatus.Text = dgvKhachhang.Rows[0].Cells[6].Value.ToString();
        }
        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtMaKH.Text != "" && txtTenKH.Text != "" && txtCMND.Text != "" && txtNgenghiep.Text != "" && txtDiachi.Text != "" && txtEmail.Text != "")
            {
                KhachHang khachhang = new KhachHang
                {
                    MaKH = Convert.ToInt32(txtMaKH.Text),
                    TenKH = txtTenKH.Text,
                    CMND = txtCMND.Text,
                    NgheNghiep = txtNgenghiep.Text,
                    DiaChi = txtDiachi.Text,
                    Email = txtEmail.Text,
                    Status = Convert.ToBoolean(cbStatus.Text == "Khóa" ? false : true)
                };
                bus.suaKH(khachhang);
                reload();
            }
            else
            {
                const string message =
                    "Bạn chưa nhập đủ thông tin!";
                const string caption = "Thông báo lỗi";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvKhachhang.DataSource = null;
            dgvKhachhang.Rows.Clear();
            dgvKhachhang.DataSource = bus.SearchKhachhang(textBox1.Text);
            if(dgvKhachhang.RowCount > 0)
                GetFirstValueDataGridView();
        }
    }
}
