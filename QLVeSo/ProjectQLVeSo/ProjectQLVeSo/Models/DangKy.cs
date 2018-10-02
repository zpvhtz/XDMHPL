using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class DangKy
    {
        public Guid IdDaiLy { get; set; }
        public Guid IdVeSo { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public int? SoLuong { get; set; }

        public DaiLy IdDaiLyNavigation { get; set; }
        public LoaiVeSo IdVeSoNavigation { get; set; }
    }
}
