//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLSV
{
    using System;
    using System.Collections.Generic;
    
    public partial class Diem
    {
        public int MaDiem { get; set; }
        public Nullable<decimal> DiemA { get; set; }
        public Nullable<decimal> DiemB { get; set; }
        public Nullable<decimal> DiemC { get; set; }
        public Nullable<int> MaSV { get; set; }
    
        public virtual SinhVien SinhVien { get; set; }
    }
}
