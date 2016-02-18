using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using CaptchaMvc.Attributes;
using DNTCms.Common.Controller;
using DNTCms.Common.Extentions;
using DNTCms.Common.Filters;
using DNTCms.DataLayer.Context;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.ServiceLayer.Contracts.Users;
using DNTCms.Utility;
using DNTCms.ViewModel.Account;
using DNTCms.Web.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MvcSiteMapProvider;

namespace DNTCms.Web.Controllers
{
    #region namespaces

    

    #endregion

    public partial class AccountController : BaseController
    {
        #region Fields

        private readonly IAuthenticationManager _authenticationManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISignInService _signInManager;
        private readonly IUserService _userService;
        #endregion

        #region Constructor

        public AccountController(IUserService userService, IUnitOfWork unitOfWork,
            ISignInService signInManager,
            IAuthenticationManager authenticationManager
           )
        {
            _userService = userService;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Login,LogOff
        [AllowAnonymous]
        [HttpGet]
        [MvcSiteMapNode(Title = "ورود به حساب", ParentKey = "Home_Index")]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[CheckReferrer]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("تصویر امنیتی را درست وارد کنید")]
        [Audit(Description = "ورود به حساب کاربری")]
        public virtual async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (_userService.CheckIsUserBanned(model.UserName))
            {
                this.AddErrors("UserName", "حساب کاربری شما مسدود شده است");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            const string emailRegPattern =
                @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            var user = Regex.IsMatch(model.UserName, emailRegPattern)
                ? await _userService.FindByEmailAsync(model.UserName, model.Password)
                : await _userService.FindAsync(model.UserName, model.Password);

            if (user != null)
            {
                await _userService.UpdateSecurityStampAsync(user.Id);
            }

            if (user == null)
            {
                this.AddErrors("UserName", "کاربر مورد نظر یافت نشد");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync
                (user.UserName, model.Password, model.RememberMe, shouldLockout: true);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    this.AddErrors("UserName",
                        $"دقیقه دوباره امتحان کنید {_userService.DefaultAccountLockoutTimeSpan} حساب شما قفل شد ! لطفا بعد از ");
                    return View(model);
                case SignInStatus.Failure:
                    this.AddErrors("UserName", "نام کاربری یا کلمه عبور  صحیح نمی باشد");
                    this.AddErrors("Password", "نام کاربری یا کلمه عبور  صحیح نمی باشد");
                    return View(model);
                default:
                    this.AddErrors("UserName",
                        "در این لحظه امکان ورود به  سابت وجود ندارد . مراتب را با مسئولان سایت در میان بگذارید"
                        );
                    return View(model);

            }

        }

        [HttpPost]
        //[CheckReferrer]
        [ValidateAntiForgeryToken]
        [Mvc5Authorize]
        [Audit(Description = "خروج از حساب کاربری")]
        public virtual async Task<ActionResult> LogOff()
        {
            var user = await _userService.FindByNameAsync(User.Identity.Name);
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            await _userService.UpdateSecurityStampAsync(user.Id);

            return RedirectToAction(MVC.Home.Index());
        }

        #endregion

        #region ConfirmEmail
        [AllowAnonymous]
        public virtual ActionResult ConfirmEmailPage(string url)
        {
            ViewBag.CallbackUrl = url;
            return View();
        }
        [AllowAnonymous]
        public virtual async Task<ActionResult> ConfirmEmail(long? userId, string code)
        {
            //if(enable confirm email feature then show confirm page)
            //return view("info")
            if (userId == null || code == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = await _userService.ConfirmEmailAsync(userId.Value, code);
            if (result.Succeeded)
                return RedirectToAction(MVC.Account.Login());
            ControllerExtentions.NotyWarning(this, "مشکلی در فعال سازی اکانت شما به وجود آمد");
            return RedirectToAction(MVC.Account.ReceiveActivatorEmail());
        }
        #endregion

        #region ExternalLogin
        [ChildActionOnly]
        public virtual ActionResult ExternalLoginsList(string returnUrl)
        {
            var viewModel = new ExternalLoginListViewModel
            {
                ReturnUrl = returnUrl,
                AuthenticationDescriptions = _authenticationManager.GetExternalAuthenticationTypes()
            };
            return PartialView(MVC.Account.Views._ExternalLoginsListPartial, viewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        //[CheckReferrer]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ChallengeResult(provider, Url.Action(MVC.Account.ExternalLoginCallback(returnUrl)));
        }

        [AllowAnonymous]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await _authenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction(MVC.Account.Login());
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await _signInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return RedirectToAction(MVC.Error.LockOut());
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View(MVC.Account.Views.ExternalLoginConfirmation, new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        //[CheckReferrer]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(MVC.Home.Index());
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _authenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View(MVC.Account.Views.ExternalLoginFailure);
                }
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await _userService.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userService.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                // this.AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }


        [AllowAnonymous]
        public virtual ActionResult ExternalLoginFailure()
        {
            return View();
        }
        #endregion

        #region ForgetPassword
        [AllowAnonymous]
        public virtual ActionResult ForgotPassword()
        {
            //if(enable forget feature then show forget page)
            //return view("info")
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {

            if (!ModelState.IsValid) return View(model);
            var user = await _userService.FindByNameAsync(model.Email);
            if (user == null || !(await _userService.IsEmailConfirmedAsync(user.Id)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                return View(MVC.Account.Views.ViewNames.ResetPasswordConfirmation);
            }

            var code = await _userService.GeneratePasswordResetTokenAsync(user.Id);
            if (Request.Url == null) return View(MVC.Account.Views.ForgotPasswordConfirmation);
            var callbackUrl = Url.Action(MVC.Account.ActionNames.ResetPassword, MVC.Account.Name,
                new { userId = user.Id, code }, protocol: Request.Url.Scheme);


            return View(MVC.Account.ActionNames.ForgotPasswordConfirmation, MVC.Account.Name);
        }

        [AllowAnonymous]
        public virtual ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        #endregion

        #region Register
        [AllowAnonymous]
        [MvcSiteMapNode(Title = "عضویت", ParentKey = "Home_Index")]
        public virtual ActionResult Register()
        {
            // if("register is enable")
            // return RedirectToAction("info)
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        // [CheckReferrer]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("تصویر امنیتی را درست وارد کنید")]
        public virtual async Task<ActionResult> Register(RegisterViewModel model)
        {
            #region Validation
            if (_userService.CheckEmailExist(model.Email, null))
                this.AddErrors("Email", "این ایمیل قبلا در سیستم ثبت شده است");
            if (!model.Password.IsSafePasword())
                this.AddErrors("Password", "این کلمه عبور به راحتی قابل تشخیص است");
            if (_userService.CheckNameForShowExist(model.NameForShow, null))
                this.AddErrors("NameForShow", "این نام نمایشی قبلا در سیستم ثبت شده است");
            if (_userService.CheckPhoneNumberExist(model.PhoneNumber, null))
                this.AddErrors("PhoneNumber", "این شماره همراه قبلا در سیستم ثبت شده است");

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #endregion SendEmail

            var userId = await _userService.Register(model);

            var code = await _userService.GenerateEmailConfirmationTokenAsync(userId);
            var callbackUrl = Url.Action(MVC.Account.ConfirmEmail(userId, code), protocol: Request.Url.Scheme);
            // await _userService.SendEmailAsync(userId, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            ControllerExtentions.NotySuccess(this, "حساب کاربری شما با موفقیت ایجاد شد. برای فعال سازی " +
                          "حساب خود به صندوق پستی خود مراجعه کنید",
                isSticky: true);

            return RedirectToAction(MVC.Account.ConfirmEmailPage(callbackUrl));
        }
        #endregion

        #region ResePassword

        [AllowAnonymous]
        public virtual ActionResult ResetPassword(string code)
        {
            //if(enable resetpass feature then show resetpass page)
            //return view("info")
            if (code == null) return HttpNotFound();

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[CheckReferrer]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("تصویر امنیتی را درست وارد کنید")]
        public virtual async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!model.Password.IsSafePasword())
                this.AddErrors("Password", "این کلمه عبور به راحتی قابل تشخیص است");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userService.FindByNameAsync(model.Email.ToLower());
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(MVC.Account.ActionNames.ResetPasswordConfirmation, MVC.Account.Name);
            }
            var result = await _userService.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false, false);
                return RedirectToAction(MVC.Account.ActionNames.ResetPasswordConfirmation, MVC.Account.Name);
            }
            this.AddErrors(result);
            ControllerExtentions.NotyError(this, ControllerExtentions.GetListOfErrors(ModelState));
            return View(model);
        }

        [AllowAnonymous]
        public virtual ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        #endregion

        #region ReceiveActivatorEmail
        [AllowAnonymous]
        public virtual ActionResult ReceiveActivatorEmail()
        {
            //if(enable receiveactivator feature then show receiveactivator page)
            //return view("info")
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        // [CheckReferrer]
        [ValidateAntiForgeryToken]
        [CaptchaVerify("تصویر امنیتی را درست وارد کنید")]
        public virtual async Task<ActionResult> ReceiveActivatorEmail(ActivationEmailViewModel viewModel)
        {
            if (!_userService.IsEmailAvailableForConfirm(viewModel.Email))
                this.AddErrors("Email", "ایمیل مورد نظر یافت نشد");
            if (_userService.CheckIsUserBannedOrDeleteByEmail(viewModel.Email))
                this.AddErrors("Email", "اکانت شما مسدود شده است");
            if (!ModelState.IsValid)
                return View(viewModel);
            var user = await _userService.FindByEmailAsync(viewModel.Email);

            //send confirmation email
            ControllerExtentions.NotySuccess(this, "ایمیلی تحت عنوان فعال سازی اکانت به آدرس ایمیل شما ارسال گردید");
            return RedirectToAction(MVC.Account.ActionNames.ReceiveActivatorEmail, MVC.Account.Name);
        }

        #endregion

        #region Validation

        [HttpPost]
        [AllowAnonymous]
        // [CheckReferrer]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult IsEmailAvailable(string email)
        {
            return _userService.IsEmailAvailableForConfirm(email) ? Json(true) : Json(false);
        }

        [HttpPost]
        [AllowAnonymous]
        // [CheckReferrer]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult CheckPassword(string password)
        {
            return password.IsSafePasword() ? Json(true) : Json(false);
        }
        [HttpPost]
        [AllowAnonymous]
        // [CheckReferrer]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult IsNameForShowExist(string nameForShow, long? id)
        {
            return _userService.CheckNameForShowExist(nameForShow, id) ? Json(false) : Json(true);
        }
        [HttpPost]
        [AllowAnonymous]
        // [CheckReferrer]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult IsEmailExist(string email, long? id)
        {
            var check = _userService.CheckEmailExist(email, id);
            return check ? Json(false) : Json(true);
        }

        [HttpPost]
        [AllowAnonymous]
        // [CheckReferrer]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult IsUserNameExist(string userName, long? id)
        {
            return _userService.CheckUserNameExist(userName, id) ? Json(false) : Json(true);
        }
        #endregion

        #region Private
        [NonAction]
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(MVC.Home.Index());
        }

        #endregion

        #region UploadAvatar
        [HttpGet]
        public virtual async Task<ActionResult> UploadAvatar()
        {
            ViewBag.Avatar = await _userService.GetCurrentUserAvatar();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowUploadSpecialFilesOnly(".png,.jpg,.gif.jpeg", justImage: true)]
        public virtual async Task<ActionResult> UploadAvatar(ChangeAvatarViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            await _userService.ChangeAvatar(viewModel);
            return RedirectToAction(MVC.Account.UploadAvatar());
        }
        #endregion
    }
}