using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Web_Project.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "متن {0} دوره نمیتواند خالی باشد")]
        [StringLength(50, ErrorMessage = "{0} نمیتواند بیش از 50 و کمتر از 10 کاراکتر باشد", MinimumLength = 10)]

        public string Title { get; set; } = string.Empty;

        [Display(Name = "توضیحات")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "متن {0} دوره نمیتواند خالی باشد")]
        [StringLength(500, ErrorMessage = "{0} نمیتواند بیش از 500 و کمتر از 30 کاراکتر باشد", MinimumLength = 30)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "{0} دوره نمیتواند خالی باشد")]
        [Range(0, 100000000, ErrorMessage = "{0} باید بین {1} و {2} باشد.")]
        public decimal? Price { get; set; }
    }
}
