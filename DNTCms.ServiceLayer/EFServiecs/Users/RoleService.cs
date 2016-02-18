using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DNTCms.DataLayer.Context;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.ServiceLayer.Contracts.Users;
using DNTCms.ServiceLayer.Security;
using DNTCms.Utility;
using EFSecondLevelCache;
using EntityFramework.Extensions;
using Microsoft.AspNet.Identity;

namespace DNTCms.ServiceLayer.EFServiecs.Users
{
    public class RoleManager : RoleManager<Role, long>, IRoleService
    {
        #region Fields
        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Role> _roles;
        #endregion

        #region Constructor
        public RoleManager(IMappingEngine mappingEngine,  IUnitOfWork unitOfWork, IRoleStore<Role, long> roleStore)
            : base(roleStore)
        {
            _unitOfWork = unitOfWork;
            _roles = _unitOfWork.Set<Role>();
            _mappingEngine = mappingEngine;
            AutoCommitEnabled = true;
        }
        #endregion

        #region FindRoleByName
        public Role FindRoleByName(string roleName)
        {
            return this.FindByName(roleName); // RoleManagerExtensions
        }
        #endregion

        #region CreateRole
        public IdentityResult CreateRole(Role role)
        {
            return this.Create(role); // RoleManagerExtensions
        }
        #endregion

        #region GetUsersOfRole
        public IList<UserRole> GetUsersOfRole(string roleName)
        {
            return Roles.Where(role => role.Name == roleName)
                             .SelectMany(role => role.Users)
                             .ToList();
        }

        #endregion

        #region GetApplicationUsersInRole
        public IList<User> GetApplicationUsersInRole(string roleName)
        {
            //var roleUserIdsQuery = from role in Roles
            //                       where role.Name == roleName
            //                       from user in role.Users
            //                       select user.UserId;

            return null; //_userService.GetUsersWithRoleIds(roleUserIdsQuery.ToArray());
        }
        #endregion

        #region FindUserRoles
        public IList<string> FindUserRoles(long userId)
        {
            var userRolesQuery = from role in Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return userRolesQuery.OrderBy(x => x.Name).Select(a => a.Name).ToList();
        }

        public IEnumerable<long> FindUserRoleIds(long userId)
        {
            var userRolesQuery = from role in Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return userRolesQuery.Select(a => a.Id).ToList();
        }

        public async Task<IList<long>> FindUserRoleIdsAsync(long userId)
        {
            var userRolesQuery = from role in Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return await userRolesQuery.Select(a => a.Id).ToListAsync();
        }


        public async Task<IList<string>> FindUserPermissions(long userId)
        {
            var userRolesQuery = from role in Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select new {role.Name};

            var roles = await userRolesQuery.AsNoTracking().ToListAsync();
            var roleNames = roles.Select(a => a.Name).ToList();
            return roleNames;
            //roleNames.Union(
            //    _permissionService.GetUserPermissionsAsList(
            //        roles.Select(a => XElement.Parse(a.Permissions)).ToList())).ToList();
        }
        #endregion

        #region GetRolesForUser
        public string[] GetRolesForUser(long userId)
        {
            var roles = FindUserRoles(userId);
            if (roles == null || !roles.Any())
            {
                return new string[] { };
            }

            return roles.ToArray();
        }

        #endregion

        #region IsUserInRole
        public bool IsUserInRole(long userId, string roleName)
        {
            var userRolesQuery = from role in Roles
                                 where role.Name == roleName
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;
            var userRole = userRolesQuery.FirstOrDefault();
            return userRole != null;
        }

        #endregion

        #region GetAllRolesAsync
        public async Task<IList<Role>> GetAllRolesAsync()
        {
            return await Roles.ToListAsync();
        }

        #endregion

        #region SeedDatabase
        /// <summary>
        /// for instal permissions with roles
        /// </summary>
        public void SeedDatabase()
        {
            var standardRoles = StandardRoles.SystemRolesWithPermissions;

            foreach (var role in from record in standardRoles
                                 let role = this.FindByName(record.RoleName)
                                 where role == null
                                 select new Role
                                     {
                                         Name = record.RoleName
                                          })
            {
               // _roles.Add(role);
            }

            _unitOfWork.SaveChanges();
        }

        #endregion

        #region DeleteAll
        public async Task RemoteAll()
        {
            await Roles.DeleteAsync();
        }
        #endregion
        
        

      

        #region AddRange
        public void AddRange(IEnumerable<Role> roles)
        {
            _unitOfWork.AddThisRange(roles);
        }
        #endregion

        #region AnyAsync
        public Task<bool> AnyAsync()
        {
            return _roles.AnyAsync();
        }
        public bool Any()
        {
            return _roles.Any();
        }
        #endregion

        #region AutoCommitEnabled
        public bool AutoCommitEnabled { get; set; }
        #endregion

        #region CheckForExisByName
        public bool CheckForExisByName(string name, long? id)
        {
            var roles = _roles.Select(a => new { Id = a.Id, Name = a.Name }).ToList();
            return id == null ? roles.Any(a => a.Name.GetFriendlyPersianName() == name.GetFriendlyPersianName())
                : roles.Any(a => id.Value != a.Id && a.Name.GetFriendlyPersianName() == name.GetFriendlyPersianName());
        }
        #endregion

       

        #region RemoveById
        public async Task RemoveById(long id)
        {
            await _roles.Where(a => a.Id == id).DeleteAsync();
        }

        #endregion

        #region CheckRoleIsSystemRoleAsync
        public async Task<bool> CheckRoleIsSystemRoleAsync(long id)
        {
            return await _roles.AnyAsync(a => a.Id == id );
        }
        #endregion

        #region GetAllAsSelectList
        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectList()
        {
            var roles =
                await _roles.AsNoTracking().Project(_mappingEngine).To<SelectListItem>().Cacheable().ToListAsync();
            return roles;
        }
        #endregion

        #region IsInDb
        public Task<bool> IsInDb(long id)
        {
            return _roles.AnyAsync(a => a.Id == id);
        }
        #endregion

      

    }
}
