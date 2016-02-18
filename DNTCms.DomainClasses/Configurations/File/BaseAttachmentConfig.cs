using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Configurations.File
{
    public class BaseAttachmentConfig : EntityTypeConfiguration<BaseAttachment>
    {
        public BaseAttachmentConfig()
        {
            ToTable("Attachments");
        }
    }
}
