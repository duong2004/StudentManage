using StudentManage.Services.Interface;
using StudentManage.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManage.ViewModels.StudentViewModels;

namespace StudentManage.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudents _studentService = new StudentRepo();
        private readonly IYears _yearService = new YearRepo();
        private readonly IKhoa _khoaService = new KhoaRepo();

        // GET: All Student
        public ActionResult Index()
        {
            var list = _studentService.GetAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            AddStudentViewModels model = new AddStudentViewModels()
            {
                Khoas = _khoaService.GetAll(),
                Years = _yearService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(AddStudentViewModels model)
        {
            _studentService.Insert(model);
            return RedirectToAction("Index");
        }
    }
}