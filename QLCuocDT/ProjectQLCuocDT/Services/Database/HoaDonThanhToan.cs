//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDonThanhToan
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public int MaSim { get; set; }
        public decimal CuocThueBao { get; set; }
        public System.DateTime NgayHD { get; set; }
        public bool ThanhToan { get; set; }
        public decimal ThanhTien { get; set; }
        public bool Status { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual Sim Sim { get; set; }
    }
}
