using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HsPXL.Data;
using HsPXL.Models;

namespace HsPXL.Pages
{
    public class StudentRazerPageModel : PageModel
    {
        private readonly HsPXL.Data.HsPXLContext _context;

        public StudentRazerPageModel(HsPXL.Data.HsPXLContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
