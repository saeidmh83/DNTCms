using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.Utility.MimeTypeHelpers
{
    public interface IAttachmentType
    {
        string MimeType
        {
            get;
        }

        string FriendlyName
        {
            get;
        }

        string Extension
        {
            get;
        }
    }

}
