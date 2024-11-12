using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class PTACartItem
    {
        public int ID { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuongMua { get; set; }
        public float DonGiaMua { get; set; }
        public float ThanhTien { get; set; }
    }
}