using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.DomainClasses.Entities.Blog
{
    /// <summary>
    /// Represents Status for ReferrerLinks
    /// </summary>
    public enum  LinkBackStatus
    {
        [Display(Name ="غیرفعال")]
        Disable,
        [Display(Name = "فعال")]
        Enable,
        [Display(Name = "لینک ها داخلی")]
        JustInternal,
        [Display(Name = "لینک ها خارجی")]
        JustExternal
    }
}
