using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DNTCms.ViewModel.Administrator.User
{
    public class AddUserViewModel
    {
        /// <summary>
        /// کلمه عبور
        /// </summary>
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        [StringLength(50, ErrorMessage = "کلمه عبور نباید کمتر از ۵ حرف و بیتشر از ۵۰ حرف باشد", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("کلمه عبور")]
        public string Password { get; set; }
        /// <summary>
        /// تکرار کلمه عبور
        /// </summary>
        [Required(ErrorMessage = "لطفا تکرار کلمه عبور را وارد کنید")]
        [DataType(DataType.Password)]
        [DisplayName("تکرار کلمه عبور")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "کلمات عبور باهم مطابقت ندارند")]
        public string ConfirmPassword { get; set; }
     
        
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل را به شکل صحیح وارد کنید")]
        [DisplayName("ایمیل")]
        [StringLength(256, ErrorMessage = "حداکثر طول ایمیل 256 حرف است")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "لطفا نام نمایشی خود را وارد کنید")]
        [DisplayName("نام نمایشی")]
        [StringLength(255, ErrorMessage = "نام نمایشی نباید کمتر از 5 حرف و بیتشر از 25۵ حرف باشد", MinimumLength = 5)]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF,۰-۹\s]*$", ErrorMessage = "لطفا فقط ازاعداد و حروف  فارسی استفاده کنید")]

        public string NameForShow { get; set; }
        [DisplayName("شماره همراه")]
        [Required(ErrorMessage = "لطفا برای تکمیل ثبت نام شماره همراه  را وارد کنید")]
        [RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "لطفا شماره همراه  را به شکل صحیح وارد کنید")]
        public string PhoneNumber { get; set; }

    }
}
