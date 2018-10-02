using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class LoaiVeSo
    {
        public LoaiVeSo()
        {
            DangKy = new HashSet<DangKy>();
            PhanPhoi = new HashSet<PhanPhoi>();
        }

        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Tinh { get; set; }
        public string TinhTrang { get; set; }

        public ICollection<DangKy> DangKy { get; set; }
        public ICollection<PhanPhoi> PhanPhoi { get; set; }
    }
}
