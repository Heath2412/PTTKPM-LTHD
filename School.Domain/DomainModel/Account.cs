using School.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace School.BLL.DomainModel
{
    public class Account
    {
        public int Id { get; set; }
        [UniqueUsername(ErrorMessage="Tên đăng nhập đã có người sử dụng")]
        [Required(ErrorMessage="Vui lòng điền tên đăng nhập")]
        [MinLength(5, ErrorMessage="Tên đăng nhập phải từ 5-32 ký tự")]
        [MaxLength(32, ErrorMessage="Tên đăng nhập phải từ 5-32 ký tự")]
        public virtual string UserName { get; set; }
        [Required(ErrorMessage="Vui lòng điền mật khẩu")]
        [MinLength(5, ErrorMessage="Mật khẩu phải có ít nhất 5 ký tự")]
        public string Password { get; set; }
        [AdminAlwaysActive]
        public bool IsActive { get; set; }

        public virtual Role Role { get; private set; }

        public void SetUserName(string userName)
        {
            this.UserName = userName;
        }

        public void SetRole(Role role)
        {
            this.Role = role;
        }

        public void SetActive(bool isActive)
        {
            this.IsActive = isActive;
        }

        public void ChangePassword(string newPassword)
        {
            this.Password = newPassword;
        }      
    }

    public class UniqueUsernameAttribute : ValidationAttribute
    {
        IService service;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is Account)
            {
                Account account = (Account)validationContext.ObjectInstance;
                service = DependencyResolver.Current.GetService<IService>();

                // check if exists another account with the same username 
                if (service.Get<Account>(m => m.Id != account.Id && m.UserName == account.UserName).Count() > 0)
                {
                    return new ValidationResult(ErrorMessage, new string[] { "UserName" });
                }
            }

            return ValidationResult.Success;
        }
    }
    public class AdminAlwaysActiveAttribute : ValidationAttribute
    {
        IService service;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is Account)
            {
                service = DependencyResolver.Current.GetService<IService>();
                Account account = (Account)validationContext.ObjectInstance;
                Account dbAccount = service.GetByID<Account>(account.Id);
                Role role = account.Role;
                if (role == null)
                    if (dbAccount != null) role = dbAccount.Role;
                if (role != null)
                {
                    if (role.Name.Equals(AccountRoles.Admin.ToString()) &&
                        account.IsActive == false)
                        return new ValidationResult(ErrorMessage, new string[] { "IsActive" });
                }
            }

            return ValidationResult.Success;
        }
    }
}
