using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Cms;

namespace DNTCms.DomainClasses.Configurations.Cms
{
   public class UserRatingConfig:EntityTypeConfiguration<UserRating>
   {
       public UserRatingConfig()
       {
           
       }
    }
}
