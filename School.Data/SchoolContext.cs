using School.BLL.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace School.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {
            Database.SetInitializer(new SchoolInitializer());
        }

        public DbSet<TestXML> TestXML { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentInClass> StudentInClass { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<StudentMark> Marks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAbility> TeacherAbitilies { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationCategory> NotificationCategories { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }

  //      public DbSet<Temp> temp { get; set; }
    }

    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            // Init role
            foreach (AccountRoles role in Enum.GetValues(typeof(AccountRoles)))
            {
                context.Roles.Add(new Role() { Name=role.ToString() });
            }

            // Init school year
            string schoolYear1 = "";
            string schoolYear2 = "";
            if (DateTime.Now.Month >= 7)
            {
                schoolYear1 = "HK 1 " + DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                schoolYear2 = "HK 2 " + DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
            }
            else
            {
                schoolYear1 = "HK 1 " + (DateTime.Now.Year-1) + "-" + DateTime.Now.Year;
                schoolYear2 = "HK 2 " + (DateTime.Now.Year-1) + "-" + DateTime.Now.Year;
            }
            context.SchoolYears.Add(new SchoolYear() { Name=schoolYear1 });
            context.SchoolYears.Add(new SchoolYear() { Name = schoolYear2 });

            // Init subject
            string[] subjects = {"Toán", "Lý", "Hóa", "Anh văn", "Sinh", "Sử", "Địa",
                                    "Công dân", "Công nghệ", "Thể dục" };
            foreach (string subject in subjects)
                context.Subjects.Add(new Subject() { Name=subject });

            base.Seed(context);
        }
    }

    public class Temp
    {
        public int Id { get; set; }
    }

    public class TestXML
    {
        public int Id { get; set; }
        [NotMapped]
        public XElement XmlWrapper{
            get { return XElement.Parse(XmlValue); }
            set { XmlValue = value.ToString(); } 
        }

        public string XmlValue { get; set; }
    }
}
