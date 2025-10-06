using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Web_Project.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "{0} نمی تواند خالی باشد")]
        public string Username { get; set; } = string.Empty;

        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "{0} نمی تواند خالی باشد")]
        [EmailAddress(ErrorMessage ="Email Address NotValid")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "{0} نمی تواند خالی باشد")]
        [PasswordPropertyText(true)]
        public string Password { get; set; } = string.Empty;

        [DisplayName("تکرار رمز عبور")]
        [Required(ErrorMessage = "{0} نمی تواند خالی باشد")]
        [PasswordPropertyText(true)]
        [Compare("Password",ErrorMessage ="رمز عبور مشابهت ندارد")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
