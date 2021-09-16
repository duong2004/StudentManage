using StudentManage.Models;
using StudentManage.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Services.Repo
{
    public class KhoaRepo : IKhoa
    {
        private readonly StudentEntities _db = new StudentEntities();
        public void Delete(Khoa khoa)
        {
            _db.Khoas.Remove(khoa);
        }

        public IEnumerable<Khoa> GetAll()
        {
            var listKhoas = _db.Khoas.AsQueryable().ToList();
            return listKhoas;
        }

        public Khoa GetById(int Id)
        {
            var khoa = _db.Khoas.Find(Id);
            return khoa;
        }

        public Khoa GetByKhoaCode(string khoaCode)
        {
            var khoa = _db.Khoas.Where(x => x.Khoa_Code == khoaCode).FirstOrDefault();
            return khoa;
        }

        public void Insert(Khoa khoa)
        {
            _db.Khoas.Add(khoa);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Khoa khoa)
        {
            _db.Entry(khoa).State = System.Data.Entity.EntityState.Modified;
        }
    }
}