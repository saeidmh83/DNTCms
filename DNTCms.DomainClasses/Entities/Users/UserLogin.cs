using System;
using DNTCms.Utility;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DNTCms.DomainClasses.Entities.Users
{
    /// <summary>
    /// نشان دهنده لیست مهیا کننده هایی که کاربر از آنها باری ورود استفاده میکند
    /// <remarks>از قبیل فیسبوک/گوگل</remarks>
    /// </summary>
    public class UserLogin : IdentityUserLogin<long>
    {
    }
}
