using School.BLL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Interfaces
{
    public interface ITeacherService : IService<Teacher>
    {
        void CreateTeacherAccount(Teacher teacher, Account account);
    }
}
