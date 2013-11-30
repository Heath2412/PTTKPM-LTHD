using School.BLL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL
{
    public interface IStudentService : IService<Student>
    {
        void CreateAccount(Student student, StudentProfile profile);
        void AddStudentsToClass(IEnumerable<Student> students, Class cl, string note="");
        void AddStudentToClass(Student student, Class cl, string note = "");
        void EditStudentMark(Student student, StudentMark mark);
    }
}
