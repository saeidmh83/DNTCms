using System;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.ServiceLayer.Contracts.Users;
using DNTCms.ServiceLayer.EFServiecs.Users;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace DNTCms.ServiceLayer.EFServiecs.Common
{
    public class SignInService : SignInManager<User, long>, ISignInService
    {

        #region Fields
        private readonly UserService _userService;
        private readonly IAuthenticationManager _authenticationManager;
        #endregion

        #region Constructor

        public SignInService(UserService userService, IAuthenticationManager authenticationManager)
            : base(userService, authenticationManager)
        {
            _userService = userService;
            _authenticationManager = authenticationManager;
        }
        #endregion

       
    }
}
