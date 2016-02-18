using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Polling;

namespace DNTCms.DomainClasses.Configurations.Polling
{
    public class PollOptionConfig : EntityTypeConfiguration<PollOption>
    {
        public PollOptionConfig()
        {

        }
    }
}
