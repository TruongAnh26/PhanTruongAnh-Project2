using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private TTCD1_QLBHEntities1 db = new TTCD1_QLBHEntities1();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(db.LOAI_SAN_PHAM.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_LSP,TEN_LOAI,TRANG_THAI")] LOAI_SAN_PHAM lOAI_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.LOAI_SAN_PHAM.Add(lOAI_SAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAI_SAN_PHAM);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_LSP,TEN_LOAI,TRANG_THAI")] LOAI_SAN_PHAM lOAI_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAI_SAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAI_SAN_PHAM);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            db.LOAI_SAN_PHAM.Remove(lOAI_SAN_PHAM);
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
