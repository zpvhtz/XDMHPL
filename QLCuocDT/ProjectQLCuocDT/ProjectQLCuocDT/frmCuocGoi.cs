using Services.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQLCuocDT
{
    public partial class frmCuocGoi : Form
    {
        private CuocGoiBUS cuocgoibus = new CuocGoiBUS();

        public frmCuocGoi()
        {
            InitializeComponent();
        }

        private void frmCuocGoi_Load(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btnTaoFile_Click(object sender, EventArgs e)
        {
            string path = Path.GetFullPath(Path.Combine(Application.StartupPath, @"../../../Assets/CuocGoi.txt"));
            Random rd = new Random();
            var myFile = File.Create(path);
            myFile.Close();
            using (StreamWriter file = new StreamWriter(path, true))
            {
                for (int i = 0; i <= 100; i++)
                {
                    DateTime tgbd = GenerateRandomDate();
                    DateTime tgkt = GenerateRandomDate(tgbd);
                    file.WriteLine(rd.Next(2, 12) + "\t" + tgbd.ToString() + "\t" + tgkt.ToString());
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(dialog.FileName);
                foreach(string line in lines)
                {
                    int macuocgoi = cuocgoibus.GetMaCuocGoi();
                    int masim = int.Parse(line.Substring(0, line.IndexOf("\t")));
                    DateTime tgbd = DateTime.Parse(line.Substring(line.IndexOf("\t") + 1, line.LastIndexOf("\t") - line.IndexOf("\t")));
                    DateTime tgkt = DateTime.Parse(line.Substring(line.LastIndexOf("\t") + 1));
                    TimeSpan ts = tgkt.Subtract(tgbd);
                    int sophut = int.Parse(Math.Ceiling(decimal.Parse(ts.TotalMinutes.ToString())).ToString());

                    cuocgoibus.AddCuocGoi(macuocgoi, masim, tgbd, tgkt, sophut);
                }
            }
            RefreshPage();
        }

        private void dgvCuocGoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaCuocGoi.Text = dgvCuocGoi.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMaSim.Text = dgvCuocGoi.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpTGBD.Value = DateTime.Parse(dgvCuocGoi.Rows[e.RowIndex].Cells[2].Value.ToString());
                dtpTGKT.Value = DateTime.Parse(dgvCuocGoi.Rows[e.RowIndex].Cells[3].Value.ToString());
                numericSoPhut.Value = int.Parse(dgvCuocGoi.Rows[e.RowIndex].Cells[4].Value.ToString());
                cbbTinhTrang.SelectedItem = dgvCuocGoi.Rows[e.RowIndex].Cells[5].Value.ToString();

                cbbTinhTrang.Enabled = true;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int macuocgoi = int.Parse(txtMaCuocGoi.Text);
            bool tinhtrang = cbbTinhTrang.SelectedItem.ToString() == "Không khoá" ? true : false;
            MessageBox.Show(cuocgoibus.EditCuocGoi(macuocgoi, tinhtrang));
            RefreshPage();
        }

        private void GetFirstValueDataGridView()
        {
            txtMaCuocGoi.Text = dgvCuocGoi.Rows[0].Cells[0].Value.ToString();
            txtMaSim.Text = dgvCuocGoi.Rows[0].Cells[1].Value.ToString();
            dtpTGBD.Value = DateTime.Parse(dgvCuocGoi.Rows[0].Cells[2].Value.ToString());
            dtpTGKT.Value = DateTime.Parse(dgvCuocGoi.Rows[0].Cells[3].Value.ToString());
            numericSoPhut.Value = int.Parse(dgvCuocGoi.Rows[0].Cells[4].Value.ToString());
            cbbTinhTrang.SelectedItem = dgvCuocGoi.Rows[0].Cells[5].Value.ToString();

            cbbTinhTrang.Enabled = true;
        }

        private void RefreshPage()
        {
            //dgvLoaiCuoc.DataSource = null;
            //dgvLoaiCuoc.Rows.Clear();
            dgvCuocGoi.DataSource = cuocgoibus.GetCuocGois();
            if(dgvCuocGoi.Rows.Count > 0)
                GetFirstValueDataGridView();
            //cbbTinhTrang.Enabled = false;
        }

        public DateTime GenerateRandomDate()
        {
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            int year = rd.Next(2010, 2018);
            int month = rd.Next(1, 12);
            int day = rd.Next(1, DateTime.DaysInMonth(year, month));
            return new DateTime(year, month, day, rd.Next(0, 23), rd.Next(0, 59), rd.Next(0, 59));
        }

        public DateTime GenerateRandomDate(DateTime tgbd)
        {
            DateTime tgkt = new DateTime();
            int hour, minute, second;
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            int random = rd.Next(1, 3);
            switch(random)
            {
                case 1:
                    //Theo s
                    second = rd.Next(0, 59);
                    tgkt = tgbd.AddSeconds(second);
                    break;
                case 2:
                    //Theo m
                    minute = rd.Next(0, 59);
                    second = rd.Next(0, 59);
                    tgkt = tgbd.AddMinutes(minute);
                    tgkt = tgkt.AddSeconds(second);
                    break;
                case 3:
                    //Theo h
                    hour = rd.Next(0, 23);
                    minute = rd.Next(0, 59);
                    second = rd.Next(0, 59);
                    tgkt = tgbd.AddHours(hour);
                    tgkt = tgkt.AddMinutes(minute);
                    tgkt = tgkt.AddSeconds(second);
                    break;
            }
            return tgkt;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Nhập vào thông tin cần tìm kiếm");
            }
            else
            {
                string search = txtTimKiem.Text;
                dgvCuocGoi.DataSource = cuocgoibus.SearchCuocGoi(search);
                GetFirstValueDataGridView();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cbbFilter.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mục cần lọc");
            }
            else
            {
                string filteritem = "";
                string filter = "null";

                switch (cbbFilter.SelectedItem.ToString())
                {
                    case "Thời gian gọi":
                        filteritem = cbbFilter.SelectedItem.ToString();
                        DateTime tgbdgoi = dtpFilterTGBD.Value;
                        DateTime tgktgoi = dtpFilterTGKT.Value;
                        dgvCuocGoi.DataSource = cuocgoibus.FilterCuocGoi(filteritem, filter, tgbdgoi, tgktgoi, 0, 0, 0, 0);
                        break;
                    case "Số phút gọi":
                        filteritem = cbbFilter.SelectedItem.ToString();
                        int sophutmin = int.Parse(Math.Round(numericFilterSoPhutMin.Value).ToString());
                        int sophutmax = int.Parse(Math.Round(numericFilterSoPhutMax.Value).ToString());
                        dgvCuocGoi.DataSource = cuocgoibus.FilterCuocGoi(filteritem, filter, null, null, sophutmin, sophutmax, 0, 0);
                        break;
                    case "Phí cuộc gọi":
                        filteritem = cbbFilter.SelectedItem.ToString();
                        decimal phicuocgoimin = numericFilterPhiCuocGoiMin.Value;
                        decimal phicuocgoimax = numericFilterPhiCuocGoiMax.Value;
                        dgvCuocGoi.DataSource = cuocgoibus.FilterCuocGoi(filteritem, filter, null, null, 0, 0, phicuocgoimin, phicuocgoimax);
                        break;
                    case "Tình trạng":
                        filteritem = cbbFilter.SelectedItem.ToString();
                        if(cbbFilterTinhTrang.SelectedItem == null)
                        {
                            MessageBox.Show("Vui lòng chọn tình trạng đễ lọc");
                            return;
                        }
                        else
                        {
                            filter = cbbFilterTinhTrang.SelectedItem.ToString();
                            dgvCuocGoi.DataSource = cuocgoibus.FilterCuocGoi(filteritem, filter, null, null, 0, 0, 0, 0);
                        }
                        break;
                }

                if (dgvCuocGoi.Rows.Count > 0)
                {
                    GetFirstValueDataGridView();
                }
            }
        }

        private void cbbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            switch(cbbFilter.SelectedItem.ToString())
            {
                case "Thời gian gọi":
                    dtpFilterTGBD.Visible = true;
                    dtpFilterTGKT.Visible = true;
                    numericFilterSoPhutMin.Visible = false;
                    numericFilterSoPhutMax.Visible = false;
                    numericFilterPhiCuocGoiMin.Visible = false;
                    numericFilterPhiCuocGoiMax.Visible = false;
                    cbbFilterTinhTrang.Visible = false;
                    break;
                case "Số phút gọi":
                    dtpFilterTGBD.Visible = false;
                    dtpFilterTGKT.Visible = false;
                    numericFilterSoPhutMin.Visible = true;
                    numericFilterSoPhutMax.Visible = true;
                    numericFilterPhiCuocGoiMin.Visible = false;
                    numericFilterPhiCuocGoiMax.Visible = false;
                    cbbFilterTinhTrang.Visible = false;
                    break;
                case "Phí cuộc gọi gọi":
                    dtpFilterTGBD.Visible = false;
                    dtpFilterTGKT.Visible = false;
                    numericFilterSoPhutMin.Visible = false;
                    numericFilterSoPhutMax.Visible = false;
                    numericFilterPhiCuocGoiMin.Visible = true;
                    numericFilterPhiCuocGoiMax.Visible = true;
                    cbbFilterTinhTrang.Visible = false;
                    break;
                case "Tình trạng":
                    dtpFilterTGBD.Visible = false;
                    dtpFilterTGKT.Visible = false;
                    numericFilterSoPhutMin.Visible = false;
                    numericFilterSoPhutMax.Visible = false;
                    numericFilterPhiCuocGoiMin.Visible = false;
                    numericFilterPhiCuocGoiMax.Visible = false;
                    cbbFilterTinhTrang.Visible = true;
                    break;
            }
        }
    }
}
