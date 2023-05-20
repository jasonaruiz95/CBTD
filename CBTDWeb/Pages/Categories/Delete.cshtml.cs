using CBTD.DataAccess;
using CBTD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category objCategory { get; set; }


        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            objCategory = new Category();


            objCategory = _db.Categories.Find(id);

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


            _db.Categories.Remove(objCategory);
            TempData["success"] = "Category removed Successfully";

            _db.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}

