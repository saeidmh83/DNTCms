using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using DNTCms.DomainClasses.Entities.Users;
using Microsoft.AspNet.Identity;

namespace DNTCms.ServiceLayer.Contracts.Users
{
    public interface IRoleService : IDisposable
    {
        /// <summary>
        /// Used to validate roles before persisting changes
        /// </summary>
        IIdentityValidator<Role> RoleValidator { get; set; }

        /// <summary>
        /// Create a role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        Task<IdentityResult> CreateAsync(Role role);

        /// <summary>
        /// Update an existing role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        Task<IdentityResult> UpdateAsync(Role role);

        /// <summary>
        /// Delete a role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        Task<IdentityResult> DeleteAsync(Role role);

        /// <summary>
        /// Returns true if the role exists
        /// </summary>
        /// <param name="roleName"/>
        /// <returns/>
        Task<bool> RoleExistsAsync(string roleName);

        /// <summary>
        /// Find a role by id
        /// </summary>
        /// <param name="roleId"/>
        /// <returns/>
        Task<Role> FindByIdAsync(long roleId);

        /// <summary>
        /// Find a role by name
        /// </summary>
        /// <param name="roleName"/>
        /// <returns/>
        Task<Role> FindByNameAsync(string roleName);
        
        Role FindRoleByName(string roleName);
        IdentityResult CreateRole(Role role);
        IList<UserRole> GetUsersOfRole(string roleName);
        IList<User> GetApplicationUsersInRole(string roleName);
        IList<string> FindUserRoles(long userId);
        string[] GetRolesForUser(long userId);
        bool IsUserInRole(long userId, string roleName);
        Task<IList<Role>> GetAllRolesAsync();
        void SeedDatabase();
        Task RemoteAll();
       
        void AddRange(IEnumerable<Role> roles);
        Task<bool> AnyAsync();
        bool AutoCommitEnabled { get; set; }
        bool Any();
        bool CheckForExisByName(string name, long? id);
        Task RemoveById(long id);
        Task<bool> CheckRoleIsSystemRoleAsync(long id);
        Task<IEnumerable<SelectListItem>> GetAllAsSelectList();
        IEnumerable<long> FindUserRoleIds(long userId);
        Task<IList<string>> FindUserPermissions(long userId);
        Task<IList<long>> FindUserRoleIdsAsync(long userId);
        /// <summary>
        /// چک کردن برای موچود بود در دیتابیس
        /// </summary>
        /// <param name="id">آی دی</param>
        /// <returns></returns>
        Task<bool> IsInDb(long id);

    }
}
