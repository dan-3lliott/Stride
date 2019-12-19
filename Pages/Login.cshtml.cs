using System;
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
                //login successful
            }
            else
            {
                //login failed
            }
        }
    }
}