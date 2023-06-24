using CBTD.ApplicationCore.Models;
using CBTD.DataAccess;
using CBTD.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class IndexModel : PageModel
	{
		private readonly UnitOfWork _unitOfWork;  //instance of unitOfWork
		public IEnumerable<Manufacturer> objManufacturerList;  //our UI front end will support showing a list of Categories

		public IndexModel(UnitOfWork unitOfWork)  //dependency injection of UOW service (which includes di for data services)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult OnGet()
		{
			objManufacturerList = _unitOfWork.Manufacturer.GetAll();
			return Page();
		}

	}
}
