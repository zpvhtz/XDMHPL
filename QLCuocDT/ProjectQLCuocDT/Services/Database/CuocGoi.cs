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
    
    public partial class CuocGoi
    {
        public int MaCuocGoi { get; set; }
        public int MaSim { get; set; }
        public System.DateTime TG_BatDau { get; set; }
        public System.DateTime TG_KetThuc { get; set; }
        public int SoPhutSD { get; set; }
        public decimal PhiCuocGoi { get; set; }
        public bool trangthai { get; set; }
    
        public virtual Sim Sim { get; set; }
    }
}
