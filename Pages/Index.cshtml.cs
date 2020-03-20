using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stride.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        public void OnPost(string user, string pass)
        {
            string auth = Database.Auth(user, pass);
            switch (auth)
            {
                case "student":
                    Response.Redirect("StudentMain");
                    break;
                case "parent":
                    Response.Redirect("StudentMain");
                    break;
                case "counselor":
                    Response.Redirect("CounselorMain");
                    break;
                default: //authentication failed
                    //show validation alert
                    ViewData["InvalidLogin"] = "alert-validate";
                    //keep username in the form, ensure that label stays up
                    ViewData["Username"] = user;
                    ViewData["HasUsername"] = "has-val";
                    break;
            }
        }
    }
}