using DNTCms.ServiceLayer.Contracts.Common;
using DNTCms.ServiceLayer.EFServiecs.Users;
using StructureMap.Configuration.DSL;

namespace DNTCms.Web.IocConfig
{
    public class ServiceLayerRegistery : Registry
    {
        public ServiceLayerRegistery()
        {
            Policies.SetAllProperties(y =>
            {
                y.OfType<IAuditLogService>();
            });
            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.AssemblyContainingType<UserService>();
            });
        }
    }
}
