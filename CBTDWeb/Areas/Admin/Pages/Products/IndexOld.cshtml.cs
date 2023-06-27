using CBTD.ApplicationCore.Models;
using CBTD.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Products
{
    public class IndexOldModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        //[BindProperty]
        public IEnumerable<Product> objProductList;

        public IndexOldModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet()
        {
            objProductList = _unitOfWork.Product.GetAll();
            return Page();
        }
    }
}
