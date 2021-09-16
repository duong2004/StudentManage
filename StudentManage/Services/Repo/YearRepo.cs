using StudentManage.Models;
using StudentManage.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Services.Repo
{
    public class YearRepo : IYears
    {
        private readonly StudentEntities _db = new StudentEntities();
        public void Delete(Year year)
        {
            _db.Years.Remove(year);
        }

        public IEnumerable<Year> GetAll()
        {
            var listYears = _db.Years.AsQueryable().OrderByDescending(x=>x.Year_Code).ToList();
            return listYears;
        }

        public Year GetById(int Id)
        {
            var year = _db.Years.Find(Id);
            return year;
        }

        public Year GetByYearCode(string yearCode)
        {
            var year = _db.Years.Where(x => x.Year_Code == yearCode).FirstOrDefault();
            return year;
        }

        public void Insert(Year year)
        {
            _db.Years.Add(year);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Year year)
        {
            _db.Entry(year).State = System.Data.Entity.EntityState.Modified;
        }
    }
}