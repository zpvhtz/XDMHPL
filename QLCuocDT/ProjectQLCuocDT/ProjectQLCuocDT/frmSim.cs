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
    public partial class frmSim : Form
    {
        private SimBUS simbus = new SimBUS();

        public frmSim()
        {
            InitializeComponent();
        }

        #region methods
        private void GetFirstValueDataGridView()
        {
            txtMaSim.Text = dgvSim.Rows[0].Cells[0].Value.ToString();
            txtSoSim.Text = dgvSim.Rows[0].Cells[1].Value.ToString();
            cbTinhTrang.SelectedItem = dgvSim.Rows[0].Cells[2].Value.ToString();
        }

        private void RefreshPage()
        {
            dgvSim.DataSource = simbus.GetSims();
            GetFirstValueDataGridView();
        }

        private bool CheckNullOrEmpty()
        {
            if (txtSoSim.Text == "")
            {
                MessageBox.Show("Cần điền vào số sim");
                return false;
            }
            return true;
        }
        #endregion

        #region events
        private void frmSim_Load(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void dgvSim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaSim.Text = dgvSim.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSoSim.Text = dgvSim.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbTinhTrang.SelectedItem = dgvSim.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaSim.Text = simbus.GetMaSim().ToString();
            txtSoSim.Clear();
            cbTinhTrang.SelectedItem = "Chưa sử dụng";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckNullOrEmpty())
            {
                int masim = int.Parse(txtMaSim.Text);
                string sosim = txtSoSim.Text;
                bool tinhtrang = cbTinhTrang.SelectedItem == "Đang sử dụng" ? true : false;
                MessageBox.Show(simbus.AddSim(masim, sosim, tinhtrang));
                RefreshPage();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int masim = int.Parse(txtMaSim.Text);
            string sosim = txtSoSim.Text;
            bool tinhtrang = cbTinhTrang.SelectedItem == "Đang sử dụng" ? true : false;
            MessageBox.Show(simbus.EditSim(masim, sosim, tinhtrang));
            RefreshPage();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtSoSim.Text == "")
            {
                MessageBox.Show("Nhập vào số sim cần tìm kiếm");
            }
            else
            {
                string search = txtSoSim.Text;
                if(simbus.SearchSim(search).Count > 0)
                {
                    DataTable data = new DataTable();
                    data.Columns.Add("Mã Sim");
                    data.Columns.Add("Số Sim");
                    data.Columns.Add("Tình trạng");
                    foreach (var item in simbus.SearchSim(search))
                    {
                        DataRow row = data.NewRow();
                        row["Mã Sim"] = item.MaSim;
                        row["Số Sim"] = item.SoSim;
                        row["Tình trạng"] = item.Status == true ? "Đang sử dụng" : "Chưa sử dụng";
                        data.Rows.Add(row);
                    }
                    dgvSim.DataSource = data;
                    GetFirstValueDataGridView();
                }
                else
                {
                    MessageBox.Show("Không có số sim cần tìm kiếm");
                }
            }
        }
        #endregion
    }
}
