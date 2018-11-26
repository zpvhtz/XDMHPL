using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class LoaiCuocModel
    {
        public int STT { get; set; }
        public string MaLoaiCuoc { get; set; }
        public System.TimeSpan TG_BatDau { get; set; }
        public System.TimeSpan TG_KetThuc { get; set; }
        public System.DateTime NgayApdung { get; set; }
        public decimal GiaCuoc { get; set; }
        public string Status { get; set; }
    }
}
