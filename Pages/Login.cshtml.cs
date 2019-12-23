using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stride.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class Login : PageModel
    {
        public void OnPost(string user, string pass)
        {
            if (Database.Auth(user, pass))
            {
                //once authenticated, go to main page
                Response.Redirect("Index");
            }
            else
            {
                //show validation alert
                ViewData["InvalidLogin"] = "alert-validate";
                //keep username in the form, ensure that label stays up
                ViewData["Username"] = user;
                ViewData["HasUsername"] = "has-val";
            }
        }
    }
}