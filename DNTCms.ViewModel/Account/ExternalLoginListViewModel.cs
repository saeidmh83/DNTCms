
using System.Collections.Generic;
using Microsoft.Owin.Security;

namespace DNTCms.ViewModel.Account
{
    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
        public IEnumerable<AuthenticationDescription> AuthenticationDescriptions { get; set; }
    }
}