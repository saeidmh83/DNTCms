using System;
using System.ComponentModel;

namespace DNTCms.ViewModel.Common
{
    public abstract class BaseViewModel
    {
        /// <summary>
        /// تاریخ درج
        /// </summary>
        [DisplayName("تاریخ درج")]
        public DateTime CreateDate { get; set; }
    }
}