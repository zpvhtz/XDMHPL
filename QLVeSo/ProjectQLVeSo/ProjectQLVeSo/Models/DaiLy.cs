using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class DaiLy
    {
        public DaiLy()
        {
            DangKy = new HashSet<DangKy>();
            PhanPhoi = new HashSet<PhanPhoi>();
        }

        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string TinhTrang { get; set; }

        public ICollection<DangKy> DangKy { get; set; }
        public ICollection<PhanPhoi> PhanPhoi { get; set; }
    }
}
