using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HsPXL.Pages.User
{
    public class UserDetailModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserDetailModel(UserManager<IdentityUser> usrManager)
        {
            _userManager = usrManager;
        }

        [BindProperty]
        [Required]
        public string Id { get; set; }

        [BindProperty]
        [Required]
        public string UserName { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }



        public async Task OnGetAsync(string id = null)
        {
            if (id == null)
            {
                IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
                Id = user.Id;
                UserName = user.UserName;
                Email = user.Email;
                Password = user.PasswordHash;
            }
            else
            {
                IdentityUser user = await _userManager.FindByIdAsync(id);
                Id = user.Id;
                UserName = user.UserName;
                Email = user.Email;
                Password = user.PasswordHash;
            }
            //   var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
        }
    }
}
