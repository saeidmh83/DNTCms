using System;

namespace DNTCms.ViewModel.Administrator.User
{
    public class UserViewModel
    {
        /// <summary>
        /// آی دی 
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// قفل شده؟
        /// </summary>
        public bool IsBanned { get; set; }
        /// <summary>
        /// اکانت سیستمی است؟
        /// </summary>
        public bool IsSystemAccount { get; set; }

        public string Email { get; set; }
    }
}
