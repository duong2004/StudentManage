using StudentManage.Models;
using StudentManage.Services.Interface;
using StudentManage.Services.Repo;
using StudentManage.ViewModels.KhoaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManage.Controllers
{
    public class KhoaController : Controller
    {
        private readonly IKhoa khoaService = new KhoaRepo();
        // GET: All Khoa
        public ActionResult Index()
        {
            var list = khoaService.GetAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateKhoa model)
        {
            if (ModelState.IsValid)
            {
                Khoa khoa = new Khoa()
                {
                    Khoa_Code = model.Khoa_Code.Trim(),
                    Khoa_Name = model.Khoa_Name.Trim()
                };
                khoaService.Insert(khoa);
                khoaService.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Khoa khoa = khoaService.GetById(Id);
            if (khoa is null)
            {
                return HttpNotFound();
            }
            EditKhoa objKhoa = new EditKhoa()
            {
                Id = khoa.Id,
                Khoa_Code = khoa.Khoa_Code,
                Khoa_Name = khoa.Khoa_Name
            };
            return View(objKhoa);
        }
        [HttpPost]
        public ActionResult Edit(EditKhoa model)
        {
            if (ModelState.IsValid)
            {
                Khoa khoa = new Khoa()
                {
                    Id = model.Id,
                    Khoa_Code = model.Khoa_Code.Trim(),
                    Khoa_Name = model.Khoa_Name.Trim()
                };
                khoaService.Update(khoa);
                khoaService.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        //[HttpPost]
        //public ActionResult Delete(int Id)
        //{
        //    Khoa khoa = khoaService.GetById(Id);
        //    if (khoa is null)
        //    {
        //        return HttpNotFound();
        //    }
        //    khoaService.Delete(khoa);
        //    khoaService.Save();
        //    return RedirectToAction("Index");
        //}

        // ajax
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            string message = "";
            bool success = false;
            Khoa khoa = khoaService.GetById(Id);
            if (khoa is null)
            {
                message = "Id tìm kiếm không tồn tại.";
                success = false;
            }
            if (khoa.StudentOfKhoas.Count > 0)
            {
                message = "Đã tồn tại sinh viên.";
                success = false;
            }
            else
            {
                khoaService.Delete(khoa);
                khoaService.Save();
                message = "Xóa thành công";
                success = true;
            }
            return Json(new { message = message, success = success }, JsonRequestBehavior.AllowGet);
        }
    }
}