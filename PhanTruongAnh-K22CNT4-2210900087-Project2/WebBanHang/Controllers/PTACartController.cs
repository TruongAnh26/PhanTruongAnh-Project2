using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Bussiness;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class PTACartController : Controller
    {
        private const string PTACartSessionKey = "PTACartSessionKey";
        private TTCD1_QLBHEntities1 db = new TTCD1_QLBHEntities1();
      
        private PTA_ShoppingCart GetCart()
        {
            var cart = Session[PTACartSessionKey] as PTA_ShoppingCart;
            if(cart == null)
            {
                cart = new PTA_ShoppingCart();
                Session[PTACartSessionKey] = cart;
            }
            return cart;
        }

        //add to cart
        public ActionResult AddToCart(int id, string TenSanPham, string HinhAnh, int SoLuongMua, float DonGiaMua)
        {

            var cart = GetCart();
            var item = new PTACartItem
            {
                ID = id,
                TenSanPham = TenSanPham,
                HinhAnh = HinhAnh,
                SoLuongMua = SoLuongMua,
                DonGiaMua = DonGiaMua,
                ThanhTien = SoLuongMua * DonGiaMua
            };
            cart.AddToCart(item);
            return RedirectToAction("Index");
        }
        // GET: PTACart
        public ActionResult Index()
        {
            var cart = GetCart();

            return View(cart.Items);
        }

        public ActionResult ThongTinThanhToan()
        {
            var cart = GetCart();
            ViewBag.TongTriGia = cart.GetTongThanhTien();
            DateTime dt = DateTime.Now;
            var MaHoaDon = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            ViewBag.MaHoaDon = MaHoaDon;
            return View(cart.Items);
        }

        //cap nhat va thanh toan
        public ActionResult ThanhToan(FormCollection form)
        {
            var cart = GetCart();
            var TenKhachHang = form["TenKhachHang"];
            var MaKhachHang = form["MaKhachHang"];
            var Email = form["Email"];
            var DienThoai = form["DienThoai"];
            var DiaChi = form["DiaChi"];
            //thogn tin don hang
            DateTime dt = DateTime.Now;
            var MaHoaDon = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            var NgayNhan = form["NgayNhan"];
            var TriGia = cart.GetTongThanhTien();
            var khachHang = Session["UserName"] as KHACH_HANG;
            int maKhach = khachHang != null ? khachHang.MA_KH : 1;
            //Them moi vao bang
            var hoaDon = new HOA_DON();
            hoaDon.MA_HD = MaHoaDon;
            hoaDon.MA_KH = maKhach;
            hoaDon.NGAY_HOA_DON = dt;
            hoaDon.NGAY_NHAN =DateTime.Parse(NgayNhan);
            hoaDon.TONG_GIA_TRI = TriGia;
            hoaDon.TEN_KHACH_HANG = TenKhachHang;
            hoaDon.DIA_CHI = DiaChi;
            hoaDon.DIEN_THOAI = DienThoai;
            db.HOA_DON.Add(hoaDon);
            db.SaveChanges();

            // lay id hoa don vua them
            int hoaDonId = db.HOA_DON.Max(o => o.ID);
            //them vao chi tiet hoa don
            foreach(var item in cart.Items)
            {
                CT_HOA_DON ct = new CT_HOA_DON();
                ct.HOA_DON_ID = hoaDonId;
                ct.SAN_PHAM_ID = item.ID;
                ct.SO_LUONG_MUA = item.SoLuongMua;
                ct.DON_GIA_MUA = item.DonGiaMua;
                ct.THANH_TIEN = item.ThanhTien;

                db.CT_HOA_DON.Add(ct);
                db.SaveChanges();
            }
            Session[PTACartSessionKey] = null;
            return RedirectToAction("CamOn");
        }

        public ActionResult CamOn()
        {

            return View();
        }

        // cap nhat gio hang
        public ActionResult UpdateFromCart(FormCollection form)
        {
            var cart = GetCart();
            var ids = form["ID"].Split(',');
            var qtys = form["SoLuongMua"].Split(',');
            for(int i = 0;i<ids.Length; i++)
            {
                int id = int.Parse(ids[i]);
                int qty = int.Parse(qtys[i]);
                cart.UpdateFromCart(id, qty);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateItemCart(int id, int qty)
        {
            var cart = GetCart();
            cart.UpdateFromCart(id, qty);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteItemCart(int id)
        {
            var cart = GetCart();
            cart.RemoveCartItem(id);
            return RedirectToAction("Index");
        }
    }
}