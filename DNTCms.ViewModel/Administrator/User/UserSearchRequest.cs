using System;
using System.ComponentModel;
using DNTCms.ViewModel.Common;

namespace DNTCms.ViewModel.Administrator.User
{
    public class UserSearchRequest : BaseSearchRequest
    {
        public string UserName { get; set; }
        /// <summary>
        /// گروه  کاربری
        /// </summary>
        [DisplayName("گروه کاربری")]
        public long? RoleId { get; set; }

    }

    public static class UserSortBy
    {
        public const string UserName = "UserName";
        public const string LastLogingDate = "LastLogingDate";
    }
}
