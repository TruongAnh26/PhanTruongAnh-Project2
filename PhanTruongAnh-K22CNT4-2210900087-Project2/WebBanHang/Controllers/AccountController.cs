using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class AccountController : Controller
    {
        private TTCD1_QLBHEntities1 db = new TTCD1_QLBHEntities1();

        // GET: Account
        public ActionResult Index()
        {
            return View(db.QUAN_TRI.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form)
        {
            var taikhoan = form["taikhoan"];
            var matkhau = form["password"];
            var isAdmin = db.QUAN_TRI.Where(x => x.TAI_KHOAN.Equals(taikhoan) && x.MAT_KHAU.Equals(matkhau)).FirstOrDefault();
            if (isAdmin != null)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            var check = db.KHACH_HANG.Where(x => x.TAI_KHOAN.Equals(taikhoan) && x.MAT_KHAU.Equals(matkhau)).FirstOrDefault();
            if(check != null)
            {
                Session["UserName"] = check;
                return Redirect("/");
            }else
            {
                ViewBag.error = "Tài khoản hoặc mật khẩu không đúng";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return Redirect("/");
        }

        /*[HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Kiểm tra tài khoản admin
            var admin = db.QUAN_TRI.SingleOrDefault(a => a.TAI_KHOAN == username && a.MAT_KHAU == password);

            if (admin != null)
            {
                // Nếu tài khoản admin, chuyển hướng tới trang quản trị
                Session["UserName"] = admin.TAI_KHOAN;
                return RedirectToAction("Dashboard", "Admin", new { area = "Admin" });
            }

            // Nếu không phải admin, kiểm tra tài khoản user
            var user = db.KHACH_HANG.SingleOrDefault(u => u.TAI_KHOAN == username && u.MAT_KHAU == password);

            if (user != null)
            {
                // Nếu là người dùng bình thường, chuyển hướng tới trang chủ
                Session["UserName"] = user.TAI_KHOAN;
                return RedirectToAction("Index", "Home");
            }

            // Nếu không tìm thấy tài khoản, hiển thị lỗi
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View();*/
        }

        /* // GET: Account/Details/5
         public ActionResult Details(string id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
             if (qUAN_TRI == null)
             {
                 return HttpNotFound();
             }
             return View(qUAN_TRI);
         }

         // GET: Account/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: Account/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "TAI_KHOAN,MAT_KHAU,TRANG_THAI")] QUAN_TRI qUAN_TRI)
         {
             if (ModelState.IsValid)
             {
                 db.QUAN_TRI.Add(qUAN_TRI);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             return View(qUAN_TRI);
         }

         // GET: Account/Edit/5
         public ActionResult Edit(string id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
             if (qUAN_TRI == null)
             {
                 return HttpNotFound();
             }
             return View(qUAN_TRI);
         }

         // POST: Account/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "TAI_KHOAN,MAT_KHAU,TRANG_THAI")] QUAN_TRI qUAN_TRI)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(qUAN_TRI).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(qUAN_TRI);
         }

         // GET: Account/Delete/5
         public ActionResult Delete(string id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
             if (qUAN_TRI == null)
             {
                 return HttpNotFound();
             }
             return View(qUAN_TRI);
         }

         // POST: Account/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(string id)
         {
             QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
             db.QUAN_TRI.Remove(qUAN_TRI);
             db.SaveChanges();
             return RedirectToAction("Index");
         }

         protected override void Dispose(bool disposing)
         {
             if (disposing)
             {
                 db.Dispose();
             }
             base.Dispose(disposing);
         }*/
    }

