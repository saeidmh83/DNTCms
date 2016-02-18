using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.Resources.Administrator.Role;

namespace DNTCms.ViewModel.Administrator.Blog
{
    public class EditDraftViewModel
    {
        public Guid Id { get; set; }
        [Display(ResourceType = typeof (EditRole_cshtml), Name = "DisplayForTitle")]
        public string Title { get; set; }

    }
}
