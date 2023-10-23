using Billing.Entities;
using Billing.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Web.Controllers
{
    //[Authorize]
    public class ManageController : Controller
    {
        private readonly SignInManager<ApplicationUser> SignInManager;
        private readonly UserManager<ApplicationUser> UserManager;

        public ManageController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }


        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage = message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed." : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set." : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set." : message == ManageMessageId.Error ? "An error has occurred." : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added." : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed." : "";
            var userId = User.Identity.Name;
            var applicationUser = await UserManager.GetUserAsync(User);
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(applicationUser),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(applicationUser),
                Logins = await UserManager.GetLoginsAsync(applicationUser),
            };
            return View(model);
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await UserManager.ChangePasswordAsync(new Entities.ApplicationUser(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.Name);
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                }

                return RedirectToAction("Index", new
                {
                Message = ManageMessageId.ChangePasswordSuccess
                }

                );
            }

            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = await UserManager.GetUserAsync(User);
                var result = await UserManager.AddPasswordAsync(applicationUser, model.NewPassword);
                if (result.Succeeded)
                {
                    var user = applicationUser;
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false);
                    }

                    return RedirectToAction("Index", new
                    {
                    Message = ManageMessageId.SetPasswordSuccess
                    }

                    );
                }

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage = message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed." : message == ManageMessageId.Error ? "An error has occurred." : "";
            var user = await UserManager.FindByIdAsync(User.Identity.Name);
            if (user == null)
            {
                return View("Error");
            }

            var userLogins = await UserManager.GetLoginsAsync(await UserManager.GetUserAsync(User));
            return View(new ManageLoginsViewModel{CurrentLogins = userLogins});
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.Name);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
            }

            base.Dispose(disposing);
        }

#region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindByIdAsync(User.Identity.Name).Result;
            if (user != null)
            {
                return user.PasswordHash != null;
            }

            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindByIdAsync(User.Identity.Name).Result;
            if (user != null)
            {
                return user.PhoneNumber != null;
            }

            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
#endregion
    }
}