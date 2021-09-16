using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManage.ViewModels.YearViewModels
{
    public class CreateYear
    {
        [Required(ErrorMessage = "Mời nhập mã năm học!")]
        [MaxLength(5, ErrorMessage = "Mã năm học có 5 kí tự"), MinLength(5, ErrorMessage = "Mã năm học có 5 kí tự")]
        public string Year_Code { get; set; }
        [Required(ErrorMessage = "Mời nhập tên năm học!")]
        [MaxLength(50, ErrorMessage = "Tên năm học tối đa là 50 kí tự")]
        public string Year_Name { get; set; }
    }
    public class EditYear : CreateYear
    {
        [Required]
        public int Id { get; set; }
    }

}