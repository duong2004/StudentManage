using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManage.ViewModels
{
    public class GetAllStudents
    {
        public int Id { get; set; }
        public string Mssv { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Khoa_Name { get; set; }
        public string YearJoin { get; set; }
    }
}