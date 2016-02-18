using System;
using System.Data.Entity;
using System.Web;
using AutoMapper;
using DNTCms.DataLayer.Context;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.ServiceLayer.Contracts.Common;
using DNTCms.ServiceLayer.Contracts.Users;
using Microsoft.AspNet.Identity;
using DNTCms.Common.Extentions;

namespace DNTCms.ServiceLayer.EFServiecs.Common
{
    ///// <summary>
    ///// ارائه دهنده سرویس لاگ آماری
    ///// </summary>
    //public class AuditLogService : IAuditLogService
    //{
    //    #region Fields
    //    private readonly IMappingEngine _mappingEngine;
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IUserService _userService;
    //    private readonly IDbSet<AuditLog> _logs;
    //    #endregion

    //    #region Ctor
    //    public AuditLogService(IUnitOfWork unitOfWork, IUserService userService, IMappingEngine mappingEngine)
    //    {
    //        _userService = userService;
    //        _unitOfWork = unitOfWork;
    //        _logs = _unitOfWork.Set<AuditLog>();
    //        _mappingEngine = mappingEngine;
    //    }
    //    #endregion

    //    #region Create
    //    public void Create(string description, AuditLogType type)
    //    {
    //        var log = new AuditLog
    //        {
    //            Description = description,
    //            CreatorId =_userService.GetCurrentUserId(),
    //            Type = type
    //        };

    //        switch (type)
    //        {
    //            case AuditLogType.JustDescription:
    //                break;
    //            case AuditLogType.Serialize:
    //                break;
    //        }
    //        _logs.Add(log);
    //        _unitOfWork.SaveChanges();
    //    }
    //    public void Create(string description, string propertyValue)
    //    {
    //        if (!propertyValue.HasValue()) Create(description, AuditLogType.JustDescription);
    //        var log = new AuditLog
    //        {
    //            Description = $"{description} با مشخصه {propertyValue}",
    //            CreatorId = _userService.GetCurrentUserId(),
    //            Type = AuditLogType.JustDescription
    //        };
    //        _logs.Add(log);
    //        _unitOfWork.SaveChanges();
    //    }
    //    #endregion

    //}
}
