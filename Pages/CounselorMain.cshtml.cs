using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stride.Pages
{
    public class CounselorMain : PageModel
    {
        public IEnumerable<string[]> Students;
        public void OnGet()
        {
            Students = Database.LoadStudents();
        }
    }
}