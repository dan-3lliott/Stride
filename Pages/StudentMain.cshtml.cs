using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stride.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class StudentMain : PageModel
    {
        public void OnGet()
        {
            if (!Database.IsAuth())
            {
                Response.Redirect("Login");
            }
            else
            {
                string[] studentData = Database.LoadSaveData();
                ViewData["name"] = studentData[0];
                ViewData["studentnumber"] = studentData[1];
                ViewData["gpa"] = studentData[2];
                ViewData["eduplan"] = studentData[3];
                ViewData["college"] = studentData[4];
                ViewData["careerpath"] = studentData[5];
                ViewData["ethnicity"] = studentData[6];
                ViewData["gender"] = studentData[7];
            }
        }
        public void OnPost(string eduplan, string college, string careerpath, string ethnicity, string gender)
        {
            Database.SaveStudentData(eduplan, college, careerpath, ethnicity, gender);
        }
    }
}