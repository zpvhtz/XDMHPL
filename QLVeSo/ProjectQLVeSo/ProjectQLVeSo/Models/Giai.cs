using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class Giai
    {
        public Giai()
        {
            KetQuaXoSo = new HashSet<KetQuaXoSo>();
        }

        public Guid Id { get; set; }
        public string MaGiai { get; set; }
        public string TenGiai { get; set; }
        public int? SoLuong { get; set; }
        public int? So { get; set; }
        public double? GiaiThuong { get; set; }

        public ICollection<KetQuaXoSo> KetQuaXoSo { get; set; }
    }
}
