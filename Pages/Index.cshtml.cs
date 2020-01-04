using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stride.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            if (!Database.IsAuth())
            {
                Response.Redirect("Login");
            }
        }
        public void OnPost(string eduplan, string college, string careerpath, string ethnicity, string gender)
        {
            Database.SaveData(eduplan, college, careerpath, ethnicity, gender);
        }
    }
}