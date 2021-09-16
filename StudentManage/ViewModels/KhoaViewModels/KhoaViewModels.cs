using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManage.ViewModels.KhoaViewModels
{
    public class CreateKhoa
    {
        [Required(ErrorMessage ="Mời nhập mã khoa.")]
        [MaxLength(5,ErrorMessage ="Mã Khoa có nhiều nhất 5 kí tự.")]
        public string Khoa_Code { get; set; }
        [Required(ErrorMessage ="Mời nhập tên khoa.")]
        [MaxLength(50,ErrorMessage ="Tên Khoa không được dài hơn 50 kí tự.")]
        public string Khoa_Name { get; set; }
    }
    public class EditKhoa : CreateKhoa
    {
        [Required]
        public int Id { get; set; }
    }
}