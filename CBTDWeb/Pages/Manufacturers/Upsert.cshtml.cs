using CBTD.ApplicationCore.Models;
using CBTD.DataAccess;
using CBTD.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class UpsertModel : PageModel
	{
		private readonly UnitOfWork _unitOfWork;
		[BindProperty]
		public Manufacturer objManufacturer { get; set; }


		public UpsertModel(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult OnGet(int? id)
		{
			objManufacturer = new Manufacturer();

			//edit mode
			if (id != 0)
			{
				objManufacturer = _unitOfWork.Manufacturer.GetById(id);
			}

			if (objManufacturer == null)
			{
				return NotFound();
			}

			//create new mode
			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			//if this is a new Manufacturer
			if (objManufacturer.Id == 0)
			{
				_unitOfWork.Manufacturer.Add(objManufacturer);
				TempData["success"] = "Manufacturer added Successfully";
			}
			//if Manufacturer exists
			else
			{
				_unitOfWork.Manufacturer.Update(objManufacturer);
				TempData["success"] = "Manufacturer updated Successfully";
			}
			_unitOfWork.Commit();//Save changes to DB

			return RedirectToPage("./Index");
		}
	}
}

