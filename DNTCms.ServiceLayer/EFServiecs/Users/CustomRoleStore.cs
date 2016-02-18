using System;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.ServiceLayer.Contracts.Users;
using Microsoft.AspNet.Identity;

namespace DNTCms.ServiceLayer.EFServiecs.Users
{
    public class CustomRoleStore : ICustomRoleStore
    {
        private readonly IRoleStore<Role, long> _roleStore;

        public CustomRoleStore(IRoleStore<Role, long> roleStore)
        {
            _roleStore = roleStore;
        }
    }
}
