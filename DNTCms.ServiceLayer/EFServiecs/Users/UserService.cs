using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DNTCms.Common.Controller;
using DNTCms.DataLayer.Context;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.ServiceLayer.Contracts.Users;
using DNTCms.ServiceLayer.CustomAspNetIdentity;
using DNTCms.ServiceLayer.Security;
using DNTCms.Utility;
using DNTCms.ViewModel.Account;
using EFSecondLevelCache;
using EFSecondLevelCache.Contracts;
using EntityFramework.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using DNTCms.Common.Extentions;
using DNTCms.ViewModel.Administrator.User;
using RefactorThis.GraphDiff;

namespace DNTCms.ServiceLayer.EFServiecs.Users
{
    public class UserService : UserManager<User, long>, IUserService
    {

        #region Fields

        private readonly HttpContextBase _httpContextBase;
        private const string DefaultAvatarPath = "~/Content/Images/default-avatar.png";
        private readonly IIdentity _identity;
        private User _user;
        private readonly IRoleService _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<User> _users;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IMappingEngine _mappingEngine;

        #endregion

        #region Constructor

        public UserService(
            HttpContextBase httpContextBase,
            IUserStore<User, long> userStore,
            IRoleService roleManager, IUnitOfWork unitOfWork, IIdentity identity,
            IMappingEngine mappingEngine, IDataProtectionProvider dataProtectionProvider,
             IIdentityMessageService smsService,
            IIdentityMessageService emailService)
            : base(userStore)
        {
            AutoCommitEnabled = true;
            _dataProtectionProvider = dataProtectionProvider;
            _mappingEngine = mappingEngine;
            EmailService = emailService;
            SmsService = smsService;
            _unitOfWork = unitOfWork;
            _users = _unitOfWork.Set<User>();
            _roleManager = roleManager;
            _identity = identity;
            CreateApplicationuserService();
            _httpContextBase = httpContextBase;
        }

        #endregion

        #region GenerateUserIdentityAsync
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            return userIdentity;
        }
        #endregion

        #region HasPassword

        public async Task<bool> HasPassword(long userId)
        {
            var user = await FindByIdAsync(userId);
            return user?.PasswordHash != null;
        }

        #endregion

        #region HasPhoneNumber
        public async Task<bool> HasPhoneNumber(long userId)
        {
            var user = await FindByIdAsync(userId);
            return user?.PhoneNumber != null;
        }
        #endregion

        #region OnValidateIdentity
        public Func<CookieValidateIdentityContext, Task> OnValidateIdentity()
        {
            return CustomSecurityStampValidator.OnValidateIdentity(
                validateInterval: TimeSpan.FromMinutes(5),
                regenerateIdentityCallback: GenerateUserIdentityAsync,
                getUserIdCallback: identity => GetCurrentUserId()
                );
        }

        #endregion

        #region SeedDatabase

        public void SeedDatabase()
        {
            const string systemAdminUserName = "09146208938";
            const string systemAdminPassword = "Admin1234@example.com";
            const string systemAdminEmail = "Admin@gmail.com";
            const string systemAdminPhoneNumber = "09146208938";
            const string systemAdminNameForShow = "مدیر مدیری";

            var user = _users.FirstOrDefault(a => a.IsSystemAccount);
            if (user == null)
            {
                user = new User
                {
                    UserName = systemAdminUserName,
                    IsSystemAccount = true,
                    Email = systemAdminEmail,
                    EmailConfirmed = true,
                    DisplayName = systemAdminNameForShow,
                    PhoneNumber = systemAdminPhoneNumber,
                    Avatar = ""

                };
                this.Create(user, systemAdminPassword);
                this.SetLockoutEnabled(user.Id, false);
            }

            var userRoles = _roleManager.FindUserRoles(user.Id);
            if (userRoles.Any(a => a == StandardRoles.Administrators)) return;
            this.AddToRole(user.Id, StandardRoles.Administrators);
        }

        #endregion

        #region GenerateUserIdentityAsync
        private static async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserService manager, User user)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            return userIdentity;
        }
        #endregion

        #region GetAllUsersAsync
        public Task<List<User>> GetAllUsersAsync()
        {
            return Users.ToListAsync();
        }
        #endregion

        #region CreateApplicationuserService

        private void CreateApplicationuserService()
        {
            ClaimsIdentityFactory = new CustomClaimsIdentityFactory();

            UserValidator = new CustomUserValidator<User, long>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true

            };

            PasswordValidator = new CustomPasswordValidator
            {
                RequiredLength = 5,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            if (_dataProtectionProvider == null) return;

            var dataProtector = _dataProtectionProvider.Create("Asp.net Identity");
            UserTokenProvider = new DataProtectorTokenProvider<User, long>(dataProtector);

        }
        #endregion

        #region DeleteAll
        public async Task RemoveAll()
        {
            await Users.DeleteAsync();
        }
        #endregion

        #region GetUsersWithRoleIds
        public IList<User> GetUsersWithRoleIds(params long[] ids)
        {
            return Users.Where(applicationUser => ids.Contains(applicationUser.Id))
                .ToList();
        }
        #endregion

        #region AutoCommitEnabled
        public bool AutoCommitEnabled { get; set; }

        #endregion

        #region Any
        public bool Any()
        {
            return _users.Any();
        }
        #endregion

        #region AddRange
        public void AddRange(IEnumerable<User> users)
        {
            _unitOfWork.AddThisRange(users);
        }
        #endregion

        #region GetPageList
        public async Task<UserListViewModel> GetPageList(UserSearchRequest search)
        {

            var users = _users.AsNoTracking().OrderBy(a => a.UserName).AsQueryable();

            if (search.RoleId.HasValue)
            {
                users =
                    users.Include(a => a.Roles)
                        .Where(a => a.Roles.Any(r => r.RoleId == search.RoleId.Value))
                        .AsQueryable();
            }

            if (search.UserName.HasValue())
                users = users.Where(a => a.UserName.Contains(search.UserName));

            var query = await users
                    .Skip((search.PageIndex - 1) * 10).Take(10).ProjectTo<UserViewModel>(_mappingEngine)
                    .ToListAsync();

            return new UserListViewModel
            {
                SearchRequest = search,
                Users = query
            };
        }
        #endregion

        #region GetForEditAsync
        public async Task<EditUserViewModel> GetForEditAsync(long id)
        {
            var userWithRoles = await
                 _users.AsNoTracking()
                     .Include(a => a.Roles)
                     .FirstOrDefaultAsync(a => a.Id == id);
            if (userWithRoles == null) return null;
            var viewModel = _mappingEngine.Map<EditUserViewModel>(userWithRoles);
            viewModel.Roles = await _roleManager.GetAllAsSelectList();
            viewModel.Roles.ToList().ForEach(a => a.Selected = viewModel.RoleId== long.Parse(a.Value));
            return viewModel;
        }

        #endregion

        #region EditUser
        public async Task<UserViewModel> EditUser(EditUserViewModel viewModel)
        {
            var user = _users.Find(viewModel.Id);
            _mappingEngine.Map(viewModel, user);
            user.UserName = viewModel.PhoneNumber;
            if (viewModel.Password.IsNotEmpty())
            {
                user.PasswordHash = PasswordHasher.HashPassword(viewModel.Password);
            }

           // if (viewModel.RoleId)
            {
                _unitOfWork.MarkAsDetached(user);
              //  viewModel.RoleIds.ToList().ForEach(roleId => user.Roles.Add(new UserRole { RoleId = roleId, UserId = user.Id }));
                _unitOfWork.Update(user, a => a.AssociatedCollection(u => u.Roles));
            }
            {
                user.Roles.Clear();
            }

            if (!await IsInRoleAsync(user.Id, StandardRoles.Administrators))
                this.UpdateSecurityStamp(user.Id);
            else await _unitOfWork.SaveAllChangesAsync();

            return await GetUserViewModel(viewModel.Id);
        }
        #endregion

        #region SetRolesToUser
        public void SetRolesToUser(User user, IEnumerable<Role> roles)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region AddUser
        public async Task<UserViewModel> AddUser(AddUserViewModel viewModel)
        {
            var user = _mappingEngine.Map<User>(viewModel);
            user.Avatar = "";
            user.UserName = viewModel.PhoneNumber;
            await CreateAsync(user, viewModel.Password);
            return await GetUserViewModel(user.Id);
        }
        #endregion

        #region Validations

        public bool CheckUserNameExist(string userName, long? id)
        {
            var users = _users.Select(a => new { Id = a.Id, a.UserName }).ToList();
            return id == null
                ? users.Any(a => string.Equals(a.UserName, userName, StringComparison.InvariantCultureIgnoreCase))
                : users.Any(a => string.Equals(a.UserName, userName, StringComparison.InvariantCultureIgnoreCase) && a.Id != id.Value);
        }

        public bool CheckEmailExist(string email, long? id)
        {
            email = email.FixGmailDots();
            return id == null
               ? _users.Any(a => a.Email == email.ToLower())
               : _users.Any(a => a.Email == email.ToLower() && a.Id != id.Value);
        }

        public bool CheckNameForShowExist(string nameForShow, long? id)
        {
            var namesForShow = _users.Select(a => new { Name = a.DisplayName, a.Id }).ToList();
            nameForShow = nameForShow.GetFriendlyPersianName();
            return id == null
             ? namesForShow.Any(a => a.Name.GetFriendlyPersianName() == nameForShow)
             : namesForShow.Any(a => a.Name.GetFriendlyPersianName() == nameForShow && a.Id != id.Value);
        }



        public bool CheckPhoneNumberExist(string phoneNumber, long? id)
        {
            return id == null
               ? _users.Any(a => a.PhoneNumber == phoneNumber)
               : _users.Any(a => a.PhoneNumber == phoneNumber && a.Id != id.Value);
        }
        #endregion

        #region override GetRolesAsync
        public async override Task<IList<string>> GetRolesAsync(long userId)
        {
            var userPermissions = await _roleManager.FindUserPermissions(userId);
            ////todo: any permission form other sections
            return userPermissions;
        }

        public bool ShouldRefreshPerissions(long userId)
        {
            var user = _users.Find(userId);
            return user.IsChangedPermissions || user.IsBanned;
        }
        #endregion

        #region CustomValidatePasswordAsync
        public async Task<string> CustomValidatePasswordAsync(string pass)
        {
            var result = await PasswordValidator.ValidateAsync(pass);
            return result.Errors.GetUserManagerErros();
        }
        #endregion

        #region ChechIsBanneduser
        public bool CheckIsUserBanned(long id)
        {
            return _users.Any(a => a.Id == id && (a.IsBanned));
        }

        public bool CheckIsUserBanned(string userName)
        {
            return _users.Any(a => a.UserName == userName.ToLower() && (a.IsBanned));
        }
        public bool CheckIsUserBannedByEmail(string email)
        {
            return _users.Any(a => a.Email == email.FixGmailDots() && (a.IsBanned));
        }


        #endregion

        #region GetEmailStore
        public IUserEmailStore<User, long> GetEmailStore()
        {
            var cast = Store as IUserEmailStore<User, long>;
            if (cast == null)
            {
                throw new NotSupportedException("not support");
            }
            return cast;
        }

        #endregion

        #region Private
        //private static string[] SplitString(string dependencies)
        //{
        //    if (dependencies == null) return new string[0];
        //    var split = from dependency in dependencies.Split(',')
        //                let lowerDependency = dependency.ToLower()
        //                where !string.IsNullOrEmpty(lowerDependency)
        //                select lowerDependency;
        //    return split.ToArray();
        //}
        private bool IsExistOneSystemAccount()
        {
            return _users.Any(a => a.IsSystemAccount);
        }
        #endregion

        #region IsEmailAvailableForConfirm
        public bool IsEmailAvailableForConfirm(string email)
        {
            email = email.FixGmailDots();
            return _users.Any(a => a.Email == email);
        }
        #endregion

        #region EditSecurityStamp
        public void EditSecurityStamp(long userId)
        {
            this.UpdateSecurityStamp(userId);
        }
        #endregion

        #region FindUserById
        public User FindUserById(long id)
        {
            return this.FindById(id);
        }
        #endregion

        #region CurrentUser
        public User GetCurrentUser()
        {
            return _user ?? (_user = this.FindById(GetCurrentUserId()));
        }

        public async Task<User> GetCurrentUserAsync()
        {
            return _user ?? (_user = await FindByIdAsync(GetCurrentUserId()));
        }

        public long GetCurrentUserId()
        {
            return long.Parse(HttpContext.Current.User.Identity.GetUserId());
        }

        public bool IsAdministrator()
        {
            return HttpContext.Current.User.IsInRole(StandardRoles.Administrators);
        }
        public bool IsDeveloper()
        {
            return HttpContext.Current.User.IsInRole(StandardRoles.Administrators);
        }
        #endregion

        #region EditIsChangedPermissionsField

        public void EditIsChangedPermissionsField()
        {
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region IsInDb
        public Task<bool> IsInDb(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Fill

        public async Task FillForEdit(EditUserViewModel viewModel)
        {
            viewModel.Roles = await _roleManager.GetAllAsSelectList();
            //if (viewModel.RoleIds != null)
            //{
            //    viewModel.Roles.ToList().ForEach(a => a.Selected = viewModel.RoleIds.Any(b => long.Parse(a.Value) == b));
            //}
        }


        #endregion

        #region DeleteAsync

        public Task DeleteAsync(long id)
        {
            return _users.Where(a => a.Id == id).DeleteAsync();
        }
        #endregion

        #region IsSystemUser

        public Task<bool> IsSystemUser(long id)
        {
            return _users.AnyAsync(a => a.Id == id && a.IsSystemAccount);
        }
        #endregion

        #region Ban
        public async Task<UserViewModel> Ban(long id, bool flag)
        {
            var user = _users.Find(id);
            user.IsBanned = flag;
            await UpdateSecurityStampAsync(id);
            return await GetUserViewModel(user.Id);
        }
        #endregion

        #region GetUserViewModel
        public Task<UserViewModel> GetUserViewModel(long id)
        {
            return _users.AsNoTracking().ProjectTo<UserViewModel>(_mappingEngine).FirstOrDefaultAsync(a => a.Id == id);
        }
        #endregion

        public async Task<IEnumerable<SelectListItem>> GetAsSelectListItem()
        {
            var currentUserId = GetCurrentUserId();
            return await _users.Where(a => a.Id != currentUserId).ProjectTo<SelectListItem>(_mappingEngine).Cacheable(new EFCachePolicy { AbsoluteExpiration = DateTime.Now.AddDays(1) }).ToListAsync();
        }

        public long Count()
        {
            return _users.LongCount();
        }

        public bool CheckIsUserBannedOrDeleteByEmail(string email)
        {
            return _users.Any(a => a.Email == email.FixGmailDots() && (a.IsBanned));
        }

        public async Task<long> Register(RegisterViewModel model)
        {
            var user = new User
            {
                Email = model.Email.FixGmailDots(),
                UserName = model.PhoneNumber,
                PhoneNumber = model.PhoneNumber,
                Avatar = ""
            };
            await CreateAsync(user, model.Password);
            await AddToRoleAsync(user.Id, StandardRoles.Administrators);
            return user.Id;
        }

        public Task<User> FindByEmailAsync(string email, string password)
        {
            email = email.FixGmailDots().ToLowerInvariant();
            var hashPass = PasswordHasher.HashPassword(password);
            return _users.FirstOrDefaultAsync(a => a.Email == email && a.PasswordHash == hashPass);
        }

        public Task<string> GetEmailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumbersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<long>> GetActualUserIdsByEmailsAsync(string[] emails)
        {
            return await _users.Where(a => emails.Contains(a.Email)).Select(a => a.Id).ToListAsync();
        }

        public async Task<IEnumerable<long>> GetActualUserIdsByPhoneNumbersAsync(string[] phoneNumbers)
        {
            return await _users.Where(a => phoneNumbers.Contains(a.PhoneNumber)).Select(a => a.Id).ToListAsync();
        }

        public async Task ChangeAvatar(ChangeAvatarViewModel viewModel)
        {
            var currentUserId = GetCurrentUserId();
            var user = await _users.FirstAsync(a => a.Id == currentUserId);
            user.Avatar = "";
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<byte[]> GetCurrentUserAvatar()
        {
            var currentUserId = GetCurrentUserId();
            return null; //_users.Where(a=>a.Id==currentUserId).Select(a=>a.AvatarFileName).FirstAsync();
        }
    }
}
