//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gunes_ticarett.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_satis
    {
        public int satis_id { get; set; }
        public Nullable<int> satis_urun { get; set; }
        public Nullable<int> satis_musteri { get; set; }
        public Nullable<int> satis_adet { get; set; }
        public Nullable<int> satis_fiyat { get; set; }
    
        public virtual tbl_musteri tbl_musteri { get; set; }
        public virtual tbl_urunler tbl_urunler { get; set; }
    }
}