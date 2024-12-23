﻿using CBTD.ApplicationCore.Models;
using CBTD.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Areas.Customer.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        

        //[BindProperty]
        public IEnumerable<Product> objProductList;
        public IEnumerable<Category> objCategoryList;

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
            objProductList = _unitOfWork.Product.GetAll(null, null, "Category,Manufacturer");
            objCategoryList = _unitOfWork.Category.GetAll(null, c => c.DisplayOrder);
            return Page();
        }
    }
}