using Microsoft.AspNetCore.Identity;

namespace OnlineCourse.Web_Project.Helpers.Validation
{
    public class PersianIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = "رمز عبور باید شامل عدد باشد."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "رمز عبور باید شامل حداقل یک کاراکتر خاص (مثل @، #، ! و ...) باشد."
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = "این ایمیل قبلا ثبت شده است."
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = "این نام کاربری قبلا ثبت شده است"
            };
        }
    }
}
