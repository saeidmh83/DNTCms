﻿using System;
using System.Web.Mvc;
using DNTCms.ServiceLayer.Contracts.Common;

namespace DNTCms.Web.Filters
{
    /// <summary>
    /// به منظور اعمال 
    /// AOP 
    /// برای لاگ فعالیت های کاربران
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AuditAttribute : ActionFilterAttribute
    {
        #region Properties
        public Type LoggableType { get; set; }
        public string Property { get; set; }
        public string Description { get; set; }
        
        public IAuditLogService AuditLogService { get; set; }
        #endregion
        
        #region OnActionExecuting
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (LogType == AuditLogType.JustDescription)
            //{
            //    var propertyValue = string.Empty;
            //    if (Property.HasValue())
            //    {
            //        var parameters = filterContext.ActionDescriptor.GetParameters();
            //        var parameterToAudit = parameters.SingleOrDefault(p => p.ParameterType == LoggableType);
            //        if (parameterToAudit != null)
            //        {
            //            var argumentToAudit = filterContext.ActionParameters[parameterToAudit.ParameterName];
            //            var propertyInfo = parameterToAudit.ParameterType.GetProperties()
            //                .First(p => Property == p.Name);

            //            var pi = argumentToAudit.GetType().GetProperty(propertyInfo.Name);
            //            propertyValue = pi.GetValue(argumentToAudit, null).ToString();
            //        }
            //    }

            //    AuditLogService.Create(Description, propertyValue);

            //}

            //base.OnActionExecuting(filterContext);
        }

        #endregion

        #region OnActionExecuted
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //if (LogType == AuditLogType.Login)
            //{
            //    AuditLogService.Create(Description, LogType);
            //}
            //if (LogType != AuditLogType.Serialize) return;
            //if (filterContext.Controller.ViewData.ModelState.IsValid)
            //{
            //    AuditLogService.Create(Description, LogType);
            //}

            //base.OnActionExecuted(filterContext);
        }

        #endregion
    }
}
