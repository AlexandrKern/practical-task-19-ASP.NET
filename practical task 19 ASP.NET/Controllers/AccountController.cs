
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using practical_task_19_ASP.NET.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using DocuSign.eSign.Client;
namespace practical_task_19_ASP.NET.Controllers
{
    public class AccountController : Controller
    {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }
            [HttpGet]
            public IActionResult Login(string returnUrl = null)
            {
                return View(new LoginViewModel { ReturnUrl = returnUrl });
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var result =
                        await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Contacts");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
                return View(model);
            }
            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel model)
            {
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        Email = model.Name,
                        UserName = model.Login,
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Contacts");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                return View(model);
            }
            [HttpPost, ValidateAntiForgeryToken]
            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Contacts");
            }
    }
}


