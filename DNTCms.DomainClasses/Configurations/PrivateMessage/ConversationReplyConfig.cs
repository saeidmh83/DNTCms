using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.PrivateMessage;

namespace DNTCms.DomainClasses.Configurations.PrivateMessage
{
    public class ConversationReplyConfig : EntityTypeConfiguration<ConversationReply>
    {
        public ConversationReplyConfig()
        {

        }
    }
}
