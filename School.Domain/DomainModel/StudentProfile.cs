using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.DomainModel
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string FatherName { get; set; }
        public string FatherJob { get; set; }
        public string MotherName { get; set; }
        public string MotherJob { get; set; }
    }
}
