using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentManage.Models;

namespace StudentManage.Services.Interface
{
    public interface IYears
    {
        IEnumerable<Year> GetAll();
        Year GetById(int Id);
        Year GetByYearCode(string yearCode);
        void Insert(Year year);
        void Update(Year year);
        void Delete(Year year);
        void Save();
    }
}