using System.Data.Entity.ModelConfiguration;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Configurations.Users
{
    /// <summary>
    /// 
    /// </summary>
   public class UserLoginConfig:EntityTypeConfiguration<UserLogin>
   {
       /// <summary>
       /// 
       /// </summary>
       public UserLoginConfig()
       {
           HasKey(l => new {l.LoginProvider, l.ProviderKey, l.UserId});
               ToTable("UserLogins");

       }
    }
}
