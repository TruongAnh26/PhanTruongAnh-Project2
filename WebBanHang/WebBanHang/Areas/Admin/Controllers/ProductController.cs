using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private TTCD1_QLBHEntities1 db = new TTCD1_QLBHEntities1();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var sAN_PHAM = db.SAN_PHAM.Include(s => s.LOAI_SAN_PHAM);
            return View(sAN_PHAM.ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.MA_LSP = new SelectList(db.LOAI_SAN_PHAM, "MA_LSP", "TEN_LOAI");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_SP,TEN_SP,MO_TA,GIA,MA_LSP,HINH_ANH,TRANG_THAI")] SAN_PHAM sAN_PHAM, HttpPostedFileBase HINH_ANH)
        {
            if (ModelState.IsValid)
            {
                if (HINH_ANH != null && HINH_ANH.ContentLength > 0)
                {
                    // Generate a unique file name
                    var fileName = Path.GetFileName(HINH_ANH.FileName);
                    var directoryPath = Server.MapPath("~/Content/Images/");

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    var path = Path.Combine(directoryPath, fileName);

                    try
                    {
                        // Save the image to the specified folder
                        HINH_ANH.SaveAs(path);
                        // Store the relative URL in the SAN_PHAM model
                        sAN_PHAM.HINH_ANH = Url.Content($"~/Content/Images/{fileName}");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Có lỗi xảy ra khi lưu ảnh: {ex.Message}");
                        ViewBag.MA_LSP = new SelectList(db.LOAI_SAN_PHAM, "MA_LSP", "TEN_LOAI", sAN_PHAM.MA_LSP);
                        return View(sAN_PHAM);
                    }
                }

                db.SAN_PHAM.Add(sAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_LSP = new SelectList(db.LOAI_SAN_PHAM, "MA_LSP", "TEN_LOAI", sAN_PHAM.MA_LSP);
            return View(sAN_PHAM);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_LSP = new SelectList(db.LOAI_SAN_PHAM, "MA_LSP", "TEN_LOAI", sAN_PHAM.MA_LSP);
            return View(sAN_PHAM);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_SP,TEN_SP,MO_TA,GIA,MA_LSP,HINH_ANH,TRANG_THAI")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_LSP = new SelectList(db.LOAI_SAN_PHAM, "MA_LSP", "TEN_LOAI", sAN_PHAM.MA_LSP);
            return View(sAN_PHAM);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            db.SAN_PHAM.Remove(sAN_PHAM);
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
        }
    }
}
