using Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class HoaDonDKModel
    {
        public int MaHD { get; set; }
        public string TenKH { get; set; }
        public string CMND { get; set; }
        public System.DateTime NgayDK { get; set; }
        public decimal ChiPhi { get; set; }
        public int MaKH { get; set; }
        public int MaSim { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
    }
}
