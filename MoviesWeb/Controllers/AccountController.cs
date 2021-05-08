using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.ViewModels.Account;
using Persistence.Identity;
using System.Threading.Tasks;

namespace MoviesWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userMgr;
        private readonly SignInManager<ApplicationUser> _signInMgr;
        public AccountController(UserManager<ApplicationUser> userMgr,
            SignInManager<ApplicationUser> signInMgr)
        {
            _userMgr = userMgr;
            _signInMgr = signInMgr;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userMgr.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await _signInMgr.SignOutAsync();
                    if ((await _signInMgr.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }
        
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInMgr.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
