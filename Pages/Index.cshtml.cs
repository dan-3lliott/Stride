using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stride.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            if (!Database.IsAuth())
            {
                Response.Redirect("Login");
            }
        }
    }
}