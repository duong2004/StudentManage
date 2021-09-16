using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentManage.Models;
using StudentManage.Services.Interface;
using StudentManage.ViewModels;
using StudentManage.ViewModels.StudentViewModels;

namespace StudentManage.Services.Repo
{
    
    public class StudentRepo : IStudents
    {
        private StudentEntities _db = new StudentEntities(); // ket noi csdl

        public void Delete(Student stu)
        {
            _db.Students.Remove(stu);
        }

        public IEnumerable<GetAllStudents> GetAll()
        {
            var listStudents = (from stu in _db.Students
                                join sk in _db.StudentOfKhoas on stu.Id equals sk.StudentID
                                join k in _db.Khoas on sk.KhoaID equals k.Id
                                join sy in _db.StudentJoinYears on stu.Id equals sy.StudentID
                                join y in _db.Years on sy.YearID equals y.Id
                                select new GetAllStudents() { 
                                    Id = stu.Id,
                                    Mssv = stu.Mssv,
                                    FirstName = stu.FirstName,
                                    LastName = stu.LastName,
                                    Khoa_Name = k.Khoa_Name,
                                    YearJoin = y.Year_Name
                                }).AsQueryable().ToList();
            return listStudents;
        }

        public GetAllStudents GetByMssv(string mssv)
        {
            IEnumerable<GetAllStudents> getAllStudents = GetAll();
            GetAllStudents stu = getAllStudents.Where(x => x.Mssv == mssv).FirstOrDefault();
            return stu;
        }

        public void Insert(AddStudentViewModels model)
        {
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Student stu)
        {
            _db.Entry(stu).State = System.Data.Entity.EntityState.Modified;
        }
    }
}