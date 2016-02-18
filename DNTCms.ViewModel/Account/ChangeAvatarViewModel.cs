using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DNTCms.ViewModel.Account
{
    public class ChangeAvatarViewModel
    {
        [Required(ErrorMessage = "لطفا تصویر مورد نظر خود را انتخاب کنید")]
        public HttpPostedFileBase Avatar { get; set; }
    }
}
