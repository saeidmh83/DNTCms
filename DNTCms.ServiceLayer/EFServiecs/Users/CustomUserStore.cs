using System;
using System.Data.Entity;
using System.Threading.Tasks;
using DNTCms.DataLayer.Context;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.ServiceLayer.Contracts.Users;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DNTCms.ServiceLayer.EFServiecs.Users
{
    public class CustomUserStore : UserStore<User, Role, long, UserLogin, UserRole, UserClaim>, ICustomUserStore
    {
        public CustomUserStore(DbContext dbContext)

            : base(dbContext)
        {
        }

    }
}
