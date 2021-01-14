using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HsPXL.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class UsersModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        public UsersModel(UserManager<IdentityUser> mgr)
        {
            userManager = mgr;
        }

        [BindProperty]
        [Required]
        public IQueryable<IdentityUser> Users { get; set; }

        public void OnGet()
        {
            Users = userManager.Users;
           
        }
    }
}
