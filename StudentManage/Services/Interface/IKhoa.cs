using StudentManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.Services.Interface
{
    public interface IKhoa
    {
        IEnumerable<Khoa> GetAll();
        Khoa GetById(int Id);
        Khoa GetByKhoaCode(string khoaCode);
        void Insert(Khoa khoa);
        void Update(Khoa khoa);
        void Delete(Khoa khoa);
        void Save();
    }
}