using CBTD.ApplicationCore.Models;
using CBTD.DataAccess;
using CBTD.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public Category objCategory { get; set; }


        public DeleteModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int? id)
        {
            objCategory = new Category();


            objCategory = _unitOfWork.Category.GetById(id);

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


            _unitOfWork.Category.Delete(objCategory);
            TempData["success"] = "Category removed Successfully";

            _unitOfWork.Commit();

            return RedirectToPage("./Index");
        }
    }
}

