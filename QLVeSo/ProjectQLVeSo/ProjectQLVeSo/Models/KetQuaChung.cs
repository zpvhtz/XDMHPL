using System;
using System.Collections.Generic;

namespace ProjectQLVeSo.Models
{
    public partial class KetQuaChung
    {
        public Guid Id { get; set; }
        public Guid IdLoaiVeSo { get; set; }
        public DateTime? Ngay { get; set; }

        public LoaiVeSo IdLoaiVeSoNavigation { get; set; }
    }
}
