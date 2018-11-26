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
                for (int i = 0; i <= 5; i++)
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
            GetFirstValueDataGridView();
            cbbTinhTrang.Enabled = false;
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
    }
}
