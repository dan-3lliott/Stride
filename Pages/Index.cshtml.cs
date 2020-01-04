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
            else
            {
                string[] studentData = Database.LoadSaveData("1234567");
                ViewData["eduplan"] = studentData[0];
                ViewData["college"] = studentData[1];
                ViewData["careerpath"] = studentData[2];
                ViewData["ethnicity"] = studentData[3];
                ViewData["gender"] = studentData[4];
            }
        }
        public void OnPost(string eduplan, string college, string careerpath, string ethnicity, string gender)
        {
            Database.SaveData(eduplan, college, careerpath, ethnicity, gender);
        }
    }
}