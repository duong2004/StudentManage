using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManage.Models;
using StudentManage.Services.Interface;
using StudentManage.Services.Repo;
using StudentManage.ViewModels.YearViewModels;

namespace StudentManage.Controllers
{
    public class YearController : Controller
    {
        private readonly IYears yearService = new YearRepo();
        public ActionResult Index()
        {
            var years = yearService.GetAll();
            return View(years);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateYear model)
        {
            if (ModelState.IsValid)
            {
                Year year = new Year()
                {
                    Year_Code = model.Year_Code.Trim(),
                    Year_Name = model.Year_Name.Trim()
                };
                yearService.Insert(year);
                yearService.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var year = yearService.GetById(Id);
            if (year == null)
            {
                return HttpNotFound();
            }
            EditYear objYear = new EditYear()
            {
                Id = year.Id,
                Year_Code = year.Year_Code,
                Year_Name = year.Year_Name
            };
            return View(objYear);
        }
        [HttpPost]
        public ActionResult Edit(EditYear model)
        {
            if (ModelState.IsValid)
            {
                Year year = new Year()
                {
                    Id = model.Id,
                    Year_Code = model.Year_Code,
                    Year_Name = model.Year_Name
                };
                yearService.Update(year);
                yearService.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult Delete(int Id)
        {
            Year year = yearService.GetById(Id);
            yearService.Delete(year);
            yearService.Save();
            return Json(new { message = "Xóa thành công", success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}