using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class PhanPhoi
    {
        public Guid Id { get; set; }
        public Guid IdDaiLy { get; set; }
        public Guid IdLoaiVeSo { get; set; }
        public DateTime? Ngay { get; set; }
        public int? SoLuongGiao { get; set; }
        public int? SoLuongBan { get; set; }
        public double? TiLe { get; set; }

        public DaiLy IdDaiLyNavigation { get; set; }
        public LoaiVeSo IdLoaiVeSoNavigation { get; set; }
    }
}
