using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class PhieuThu
    {
        public Guid Id { get; set; }
        public string MaPhieuThu { get; set; }
        public Guid IdDaiLy { get; set; }
        public DateTime? Ngay { get; set; }
        public double? TongTien { get; set; }

        public DaiLy IdDaiLyNavigation { get; set; }
    }
}
