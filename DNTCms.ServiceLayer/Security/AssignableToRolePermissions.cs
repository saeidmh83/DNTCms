using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace DNTCms.ServiceLayer.Security
{
    public static class AssignableToRolePermissions
    {
        #region Fields

        private static readonly Lazy<IEnumerable<PermissionModel>> PermissionsLazy =
            new Lazy<IEnumerable<PermissionModel>>(GetPermision, LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<IEnumerable<string>> PermissionNamesLazy = new Lazy<IEnumerable<string>>(
            GetPermisionNames, LazyThreadSafetyMode.ExecutionAndPublication);
        #endregion

        #region permissionNames
        public const string CanManageUser = nameof(CanManageUser);
        public const string CanViewErrorLogs = nameof(CanViewErrorLogs);
        public const string CanViewNotifications = nameof(CanViewNotifications);
        #endregion //permissions

        #region Categories

        public const string CanManageCategory = "CanManageCategory";
        public const string CanCreateCategory = "CanCreateCategory";
        public const string CanEditCategory = "CanEditCategory";
        public const string CanViewCategory = "CanViewCategory";
        public const string CanDeleteCategroy = "CanDeleteCategory";
        #endregion

        #region Permissions
        public static readonly PermissionModel CanManageUserPermission = new PermissionModel { Name = CanManageUser, Category = CanManageCategory, Description = "می توانند کاربران را مدیریت کنند" };
        public static readonly PermissionModel CanViewErrorLogsPermission = new PermissionModel { Name = CanViewErrorLogs, Category = CanViewCategory, Description = "می توانند خطاهای سیستم را مشاهده کنند" };
        public static readonly PermissionModel CanViewNotificationsPermission = new PermissionModel { Name = CanViewNotifications, Category = CanViewCategory, Description = "می توانند هشدارهای سیستمی خود را مشاهده کنند" };
        #endregion

        #region Properties
        public static IEnumerable<PermissionModel> Permissions => PermissionsLazy.Value;

        public static IEnumerable<string> PermissionNames => PermissionNamesLazy.Value;

        #endregion

        #region GetAllPermisions
        private static IEnumerable<PermissionModel> GetPermision()
        {
            return new List<PermissionModel>
            {
                CanManageUserPermission,
                CanViewErrorLogsPermission,
                CanViewNotificationsPermission
            };
        }

        private static IEnumerable<string> GetPermisionNames()
        {
            return new List<string>()
            {
                CanViewErrorLogs,
                CanViewNotifications,
                CanManageUser
            };
        }
        #endregion

        #region GetAsSelectedList
        public static IEnumerable<SelectListItem> GetAsSelectListItems()
        {
            return Permissions.Select(a => new SelectListItem { Text = a.Description, Value = a.Name }).ToList();
        }
        #endregion
        
        public static IEnumerable<string> GetBaseSettingPermissions()
        {
            return new List<string>
            {

            };
        }
    }
}
