//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOA_DON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOA_DON()
        {
            this.CT_HOA_DON = new HashSet<CT_HOA_DON>();
        }
    
        public int ID { get; set; }
        public string MA_HD { get; set; }
        public Nullable<int> MA_KH { get; set; }
        public Nullable<System.DateTime> NGAY_HOA_DON { get; set; }
        public Nullable<System.DateTime> NGAY_NHAN { get; set; }
        public string TEN_KHACH_HANG { get; set; }
        public string DIA_CHI { get; set; }
        public Nullable<double> TONG_GIA_TRI { get; set; }
        public Nullable<byte> TRANG_THAI { get; set; }
        public string DIEN_THOAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOA_DON> CT_HOA_DON { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
    }
}