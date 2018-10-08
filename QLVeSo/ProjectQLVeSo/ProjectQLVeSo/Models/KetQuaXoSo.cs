using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class KetQuaXoSo
    {
        public Guid Id { get; set; }
        public string MaKetQua { get; set; }
        public Guid IdLoaiVeSo { get; set; }
        public DateTime? Ngay { get; set; }
        public Guid IdGiai { get; set; }
        public string SoTrung { get; set; }

        public Giai IdGiaiNavigation { get; set; }
        public LoaiVeSo IdLoaiVeSoNavigation { get; set; }
    }
}
