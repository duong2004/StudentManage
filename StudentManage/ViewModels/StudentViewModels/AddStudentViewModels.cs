using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentManage.Models;

namespace StudentManage.ViewModels.StudentViewModels
{
    public class AddStudentViewModels
    {
        public string Mssv { get; set; }
        [Required(ErrorMessage ="Mời nhập họ sinh viên.")]
        [MaxLength(30,ErrorMessage ="Tối đa 30 kí tự.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Mời nhập tên sinh viên.")]
        [MaxLength(10,ErrorMessage ="Tối đa 10 kí tự.")]
        public string LastName { get; set; }
        [MaxLength(200,ErrorMessage ="Tối đa 200 kí tự.")]
        public string Address { get; set; }
        public IEnumerable<Year> Years { get; set; }
        public IEnumerable<Khoa> Khoas { get; set; }
        public int YearID { get; set; }
        public int KhoaID { get; set; }
    }
}