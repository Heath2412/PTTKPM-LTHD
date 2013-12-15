using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.DomainModel
{
    public enum ClassState
    {
        Open,
        Closed
    }

    public class Class : Entity
    {
        public ClassState State { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
