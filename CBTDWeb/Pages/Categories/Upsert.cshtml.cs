using CBTD.DataAccess;
using CBTD.Models;
using CBTD.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Categories
{
	public class UpsertModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
		public Category objCategory { get; set; }


		public UpsertModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult OnGet(int? id)
		{
			objCategory = new Category();

			//edit mode
			if (id != 0)
			{
				objCategory = _unitOfWork.Category.GetById(id);
			}

			if (objCategory == null)
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

			//if this is a new category
			if (objCategory.Id == 0)
			{
                _unitOfWork.Category.Add(objCategory);
				TempData["success"] = "Category added Successfully";
			}
			//if category exists
			else
			{
                _unitOfWork.Category.Update(objCategory);
				TempData["success"] = "Category updated Successfully";
			}
            _unitOfWork.Commit();//Save changes to DB

			return RedirectToPage("./Index");
		}
	}
}

