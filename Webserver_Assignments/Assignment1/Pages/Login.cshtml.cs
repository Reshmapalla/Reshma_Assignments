using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignments.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public int password { get; set; }
        public string message;

        public void OnGet()
        {
        }
        public void OnPost()
        {
            if(username=="virat" && password == 12345)
            {
                message = "login Successful!!!";
            }
            else
            {
                message = "login UnSuccessFull!!!";
            }
        }
    }
}
