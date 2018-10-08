using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class CongNo
    {
        public Guid Id { get; set; }
        public string MaCongNo { get; set; }
        public Guid IdDaiLy { get; set; }
        public DateTime? Ngay { get; set; }
        public double? TongTien { get; set; }

        public DaiLy IdDaiLyNavigation { get; set; }
    }
}
