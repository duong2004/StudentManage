using StudentManage.Models;
using StudentManage.ViewModels;
using StudentManage.ViewModels.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Services.Interface
{
    public interface IStudents
    {
        IEnumerable<GetAllStudents> GetAll();
        GetAllStudents GetByMssv(string mssv);
        void Insert(AddStudentViewModels stu);
        void Update(Student stu);
        void Delete(Student stu);
        void Save();
    }
}
