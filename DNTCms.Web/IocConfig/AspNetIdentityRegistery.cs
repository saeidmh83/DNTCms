using System.Data.Entity;
using System.Web;
using DNTCms.DataLayer.Context;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.ServiceLayer.Contracts.Users;
using DNTCms.ServiceLayer.EFServiecs.Common;
using DNTCms.ServiceLayer.EFServiecs.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace DNTCms.Web.IocConfig
{
    public class AspNetIdentityRegistery : Registry
    {
        public AspNetIdentityRegistery()
        {
            For<ApplicationDbContext>().HybridHttpOrThreadLocalScoped()
                               .Use(context => (ApplicationDbContext)context.GetInstance<IUnitOfWork>());

            For<DbContext>().HybridHttpOrThreadLocalScoped()
                 .Use(context => (ApplicationDbContext)context.GetInstance<IUnitOfWork>());

            For<IUserStore<User, long>>()
                 .HybridHttpOrThreadLocalScoped()
                 .Use<UserStore<User, Role, long, UserLogin, UserRole, UserClaim>>();


            For<IRoleStore<Role, long>>()
                 .HybridHttpOrThreadLocalScoped()
                 .Use<RoleStore<Role, long, UserRole>>();
           
            For<IAuthenticationManager>()
                 .Use(() => HttpContext.Current.GetOwinContext().Authentication);

            For<ISignInService>()
                 .HybridHttpOrThreadLocalScoped()
                 .Use<SignInService>();

            For<IRoleService>()
                 .HybridHttpOrThreadLocalScoped()
                 .Use<RoleManager>();

            For<IIdentityMessageService>().Use<SmsService>();
            For<IIdentityMessageService>().Use<EmailService>();

            For<IUserService>().HybridHttpOrThreadLocalScoped()
               .Use<UserService>()
               .Ctor<IIdentityMessageService>("smsService").Is<SmsService>()
               .Ctor<IIdentityMessageService>("emailService").Is<EmailService>()
               .Setter<IIdentityMessageService>(userManager => userManager.SmsService).Is<SmsService>()
               .Setter<IIdentityMessageService>(userManager => userManager.EmailService).Is<EmailService>();

            For<UserService>().HybridHttpOrThreadLocalScoped()
                 .Use(context => (UserService)context.GetInstance<IUserService>());

            For<ICustomRoleStore>()
                      .HybridHttpOrThreadLocalScoped()
                      .Use<CustomRoleStore>();

            For<ICustomUserStore>()
                  .HybridHttpOrThreadLocalScoped()
                  .Use<CustomUserStore>();
            
            For<IUnitOfWork>()
                  .HybridHttpOrThreadLocalScoped()
                  .Use<ApplicationDbContext>();

        }
    }

}
