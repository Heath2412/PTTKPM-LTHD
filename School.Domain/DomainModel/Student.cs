using School.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

namespace School.BLL.DomainModel
{
    public class Student
    {
        public int Id { get; set; }
        [UniqueStudentCode(ErrorMessage="Mã học sinh đã tồn tại")]
        [Required(ErrorMessage="Vui lòng điền mã học sinh")]
        public string StudentCode { get; set; }
        [Required(ErrorMessage="Vui lòng điền tên học sinh")]
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime BirthDay { get; set; }
        [NotMapped]
        public XElement XmlSubcriber
        {
            get { return XElement.Parse(Subcribers); }
            set { Subcribers = value.ToString(); }
        }
        private string Subcribers { get; set; }
        [Required(ErrorMessage="Vui lòng chọn lớp")]
        public int CurrentClassId { get; set; }
        public virtual Class CurrentClass { get; set; }
        public virtual Account Account { get; set; }
        public virtual StudentProfile Profile { get; set; }

        public Student()
        {
        }
    }

    public class UniqueStudentCodeAttribute : ValidationAttribute
    {
        IService service;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectType == typeof(Student))
            {
                Student student = (Student)validationContext.ObjectInstance;
                service = DependencyResolver.Current.GetService<IService>();

                // check if exists another student with the same studentcode 
                if (service.Get<Student>(m => m.Id != student.Id && m.StudentCode == student.StudentCode).Count() > 0)
                {
                    return new ValidationResult(ErrorMessage, new string[] { "StudentCode" });
                }
            }

            return ValidationResult.Success;
        }
    }
}
