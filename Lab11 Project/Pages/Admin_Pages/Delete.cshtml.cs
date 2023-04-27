using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab11_Project.Models;

namespace Lab11_Project.Pages.Admin_Pages
{
    public class DeleteModel : PageModel
    {
		private readonly DB db;
		private readonly ILogger<DeleteModel> _logger;

		public DeleteModel(ILogger<DeleteModel> logger, DB My_dB)
		{
			_logger = logger;
			db = My_dB;
		}
		public void OnGet()
        {
        }
    }
}
