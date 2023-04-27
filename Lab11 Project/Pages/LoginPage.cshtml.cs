using Lab11_Project.Models;
using Lab11_Project.Pages.User_Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Lab11_Project.Pages
{
    public class LoginPageModel : PageModel
    {
		
		private readonly ILogger<LoginPageModel> _logger;
		private readonly DB db;
        [BindProperty]
        [Required(ErrorMessage = "Please Enter Your Email.")]
        public string Email { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please Enter Your Password.")]
        public string Password { get; set; }

        public LoginPageModel(ILogger<LoginPageModel> logger, DB My_dB)
		{
			_logger = logger;
			db = My_dB;
		}
		public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (db.CheckUserCredentials(Email, Password))
            {
                var user = db.GetUserByEmail(Email);
                if (user.UserType == 1)
                {
                    return RedirectToPage("/Admin_Pages/Main");
                }
                else
                {
                    return RedirectToPage("/User_Pages/UserMain");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return Page();
            }
        }

    }
}
