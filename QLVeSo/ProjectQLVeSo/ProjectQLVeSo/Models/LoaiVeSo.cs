using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class LoaiVeSo
    {
        public LoaiVeSo()
        {
            DangKy = new HashSet<DangKy>();
            KetQuaChung = new HashSet<KetQuaChung>();
            KetQuaXoSo = new HashSet<KetQuaXoSo>();
            PhanPhoi = new HashSet<PhanPhoi>();
        }

        public Guid Id { get; set; }
        public string MaLoaiVeSo { get; set; }
        public string Tinh { get; set; }
        public string TinhTrang { get; set; }

        public ICollection<DangKy> DangKy { get; set; }
        public ICollection<KetQuaChung> KetQuaChung { get; set; }
        public ICollection<KetQuaXoSo> KetQuaXoSo { get; set; }
        public ICollection<PhanPhoi> PhanPhoi { get; set; }
    }
}
