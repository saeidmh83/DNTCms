using System.ComponentModel.DataAnnotations;

namespace DNTCms.ViewModel.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل ضروریست")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل خود را به شکل صحیح وارد کنید")]
        public string Email { get; set; }
    }
}