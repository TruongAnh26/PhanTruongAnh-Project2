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
    
    public partial class KHACH_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACH_HANG()
        {
            this.HOA_DON = new HashSet<HOA_DON>();
        }
    
        public int MA_KH { get; set; }
        public string HO_TEN { get; set; }
        public string TAI_KHOAN { get; set; }
        public string MAT_KHAU { get; set; }
        public string DIEN_THOAI { get; set; }
        public string EMAIL { get; set; }
        public Nullable<bool> GIOI_TINH { get; set; }
        public Nullable<bool> TRANG_THAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOA_DON> HOA_DON { get; set; }
    }
}
