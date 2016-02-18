using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.ViewModel.Common
{
    public abstract class BaseRowVersion : BaseIsDelete
    {
        public byte[] RowVersion { get; set; }
    }
}
