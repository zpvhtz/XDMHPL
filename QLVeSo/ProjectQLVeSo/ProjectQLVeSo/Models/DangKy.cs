using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class DangKy
    {
        public Guid Id { get; set; }
        public Guid IdDaiLy { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public int? SoLuong { get; set; }

        public DaiLy IdDaiLyNavigation { get; set; }
    }
}
