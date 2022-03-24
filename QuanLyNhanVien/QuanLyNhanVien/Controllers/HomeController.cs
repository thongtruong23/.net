using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanVien.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Thông tin sẽ hiển thị tại đây.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Liên hệ.";

            return View();
        }
    }
}