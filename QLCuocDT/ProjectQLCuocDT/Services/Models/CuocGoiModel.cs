using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class CuocGoiModel
    {
        public int MaCuocGoi { get; set; }
        public int MaSim { get; set; }
        public System.DateTime TG_BatDau { get; set; }
        public System.DateTime TG_KetThuc { get; set; }
        public int SoPhutSD { get; set; }
        public string trangthai { get; set; }
    }
}
