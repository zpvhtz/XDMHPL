using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class DaiLy
    {
        public DaiLy()
        {
            CongNo = new HashSet<CongNo>();
            DangKy = new HashSet<DangKy>();
            PhanPhoi = new HashSet<PhanPhoi>();
            PhieuThu = new HashSet<PhieuThu>();
        }

        public Guid Id { get; set; }
        public string MaDaiLy { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string TinhTrang { get; set; }

        public ICollection<CongNo> CongNo { get; set; }
        public ICollection<DangKy> DangKy { get; set; }
        public ICollection<PhanPhoi> PhanPhoi { get; set; }
        public ICollection<PhieuThu> PhieuThu { get; set; }
    }
}
