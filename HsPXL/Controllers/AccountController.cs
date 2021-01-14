using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HsPXL.ViewModels;
using Microsoft.Extensions.Logging;

namespace HsPXL.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> user,  SignInManager<IdentityUser> signIn, ILogger<AccountController> logger ,RoleManager<IdentityRole> role)
        {
            _userManager = user;
            _signInManager = signIn;
            _logger = logger;
            _roleManager = role;
        }
        [HttpGet]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {//extra check for role

                IdentityUser user = await _userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        //  var role = _userManager.GetRolesAsync(user);
                        if (user.NormalizedUserName == "ADMIN")
                        {
                            return RedirectToAction("Index", "Home");   
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ViewResult Register()
        {
            return View(new LoginModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    var userOutDb = await _userManager.FindByEmailAsync(model.Email);

                    var identityRole = await _roleManager.FindByNameAsync("User");

                    await _userManager.AddToRoleAsync(userOutDb,identityRole.Name);


                    await _signInManager.SignInAsync(user, isPersistent: false); //(isPersistent: false) Session Cookie stored in browser, permenant  cookie is stored in user machine .

                    return RedirectToAction("Index","home");
                }

                foreach( var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    _logger.LogError($"{error} this object cause error re-check input or code");
                }
            }
            return View();
        }
    }
}
