using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DNTCms.DomainClasses.Entities.Users
{
    /// <summary>
    /// ادعای های کاربر سیستم مبنی بر دسترسی ها
    /// </summary>
    public class UserClaim : IdentityUserClaim<long>
    {
    }
}
