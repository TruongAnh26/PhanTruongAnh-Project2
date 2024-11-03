using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using WebBanHang.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        private TTCD1_QLBHEntities1 db = new TTCD1_QLBHEntities1();
        public ActionResult Index()
        {
            var sAN_PHAM = db.SAN_PHAM.Include(s => s.LOAI_SAN_PHAM);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult News() 
        {
            return View();
        }
    }
}