using System.ComponentModel.DataAnnotations;

namespace DNTCms.ViewModel.ManageAccount
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}