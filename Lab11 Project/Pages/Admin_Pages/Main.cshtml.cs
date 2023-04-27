using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab11_Project.Models;
using Lab11_Project.Pages.User_Pages;
using System.Data;

namespace Lab11_Project.Pages.Admin_Pages
{
    public class MainModel : PageModel
    {
        public int GetTotalNumUsers { get; set; }
		public List<User> allusers { get; set; }

		private readonly DB db;
		private readonly ILogger<MainModel> _logger;

		public MainModel(ILogger<MainModel> logger, DB My_dB)
		{
			_logger = logger;
			db = My_dB;
		}
		public void OnGet()
        {
			GetTotalNumUsers = db.Gettotal();
			allusers=db.GetUsers();


		}
    }
}
