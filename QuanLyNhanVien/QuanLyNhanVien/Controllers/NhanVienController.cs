using QuanLyNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace QuanLyNhanVien.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index(string searchString, int? page)
        {

            var listNhanVien = new QuanLyNhanVienConnectionString().NhanVien.ToList();

            //Phan trang
            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);


            //Tim kiem
            ViewBag.Keyword = searchString;

            if(!String.IsNullOrEmpty(searchString))
            {
                listNhanVien = listNhanVien.Where(a => a.HoVaTen.Contains(searchString)).ToList();

            }    

            return View(listNhanVien.ToPagedList(pageNumber, pageSize));
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int id)
        {
            var context = new QuanLyNhanVienConnectionString();
            var detailNhanVien = context.NhanVien.Find(id);
            var chucVuSelectItem = new SelectList(context.ChucVu, "Id", "TenChucVu");
            ViewBag.IdChucVu = chucVuSelectItem;

            return View(detailNhanVien);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            var context = new QuanLyNhanVienConnectionString();
            var chucVuSelectItem = new SelectList(context.ChucVu, "Id", "TenChucVu");
            ViewBag.IdChucVu = chucVuSelectItem;
            return View();
        }

        // POST: NhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new QuanLyNhanVienConnectionString(); 
                context.NhanVien.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new QuanLyNhanVienConnectionString(); 
            var editNhanVien = context.NhanVien.Find(id);
            var chucVuSelectItem = new SelectList(context.ChucVu, "Id", "TenChucVu", editNhanVien.IdChucVu);
            ViewBag.IdChucVu = chucVuSelectItem;

            return View(editNhanVien);
        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(NhanVien model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new QuanLyNhanVienConnectionString();
                var oldItem = context.NhanVien.Find(model.Id);
                oldItem.HoVaTen = model.HoVaTen;
                oldItem.ChucVu = model.ChucVu;
                oldItem.CMND = model.CMND;
                oldItem.GioiTinh = model.GioiTinh;
                oldItem.Email = model.Email;
                oldItem.DiaChi = model.DiaChi;
                oldItem.SoDienThoai = model.SoDienThoai;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new QuanLyNhanVienConnectionString();
            var deleteNhanVien = context.NhanVien.Find(id);

            return View(deleteNhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new QuanLyNhanVienConnectionString();
                var deleteNhanVien = context.NhanVien.Find(id);
                context.NhanVien.Remove(deleteNhanVien);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
