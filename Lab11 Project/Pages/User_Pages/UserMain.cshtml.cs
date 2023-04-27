using Lab11_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab11_Project.Pages.User_Pages
{
    public class UserMainModel : PageModel
    {
		private readonly DB db;
		private readonly ILogger<UserMainModel> _logger;

		public UserMainModel(ILogger<UserMainModel> logger, DB My_dB)
		{
			_logger = logger;
			db = My_dB;
		}
		public void OnGet()
        {
        }
    }
}
