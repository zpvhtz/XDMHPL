using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class HoaDonThanhToanModel
    {
        public int MaHD { get; set; }
        public string TenKH { get; set; }
        public string SoSim { get; set; }
        public decimal CuocThueBao { get; set; }
        public System.DateTime NgayHD { get; set; }
        public string ThanhToan { get; set; }
        public decimal ThanhTien { get; set; }
        public string TinhTrang { get; set; }
    }
}
