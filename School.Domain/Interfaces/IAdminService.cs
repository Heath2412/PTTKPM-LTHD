using School.BLL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Interfaces
{
    public interface IAdminService
    {
        void AddClass(Class cl);
        void CloseClass(object id);
        void OpenClass(object id);

        void AddSubject(Subject subject);
        void CloseSubject(object id);
        void OpenSubject(object id);

        void CreateMinistryAccount(Account account);
    }
}
