using System.Collections.Generic;

namespace DNTCms.ServiceLayer.Security
{
    public  class PermissionRecord
    {
        public string RoleName { get; set; }
        public IEnumerable<PermissionModel> Permissions { get; set; }
    }
}
