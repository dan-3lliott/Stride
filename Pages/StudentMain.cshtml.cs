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
                ViewData["major"] = studentData[5];
                ViewData["careerpath"] = studentData[6];
                ViewData["ethnicity"] = studentData[7];
                ViewData["gender"] = studentData[8];
                ViewData["ncaa"] = studentData[9];
                ViewData["firstgen"] = studentData[10];
                ViewData["onlineinterest"] = studentData[11];
            }
        }
        public void OnPost(string eduplan, string college, string major, string careerpath, string ethnicity, string gender, string ncaa, string firstgen, string onlineinterest)
        {
            Database.SaveStudentData(eduplan, college, major, careerpath, ethnicity, gender, ncaa, firstgen, onlineinterest);
        }
    }
}