using CBTD.ApplicationCore.Models;
using CBTD.DataAccess;
using CBTD.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
		private readonly UnitOfWork _unitOfWork;  //instance of unitOfWork
		public IEnumerable<Category> objCategoryList;  //our UI front end will support showing a list of Categories

		public IndexModel(UnitOfWork unitOfWork)  //dependency injection of UOW service (which includes di for data services)
		{
            _unitOfWork = unitOfWork;
		}

		public IActionResult OnGet()
		{
			objCategoryList = _unitOfWork.Category.GetAll();
			return Page();
		}

	}
}
