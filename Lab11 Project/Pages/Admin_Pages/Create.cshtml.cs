using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab11_Project.Models;

namespace Lab11_Project.Pages.User_Pages
{
    public class CreateModel : PageModel
    {
		private readonly DB db;
		private readonly ILogger<CreateModel> _logger;

		public CreateModel(ILogger<CreateModel> logger, DB My_dB)
		{
			_logger = logger;
			db = My_dB;
		}
		public void OnGet()
        {
        }
    }
}
