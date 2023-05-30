using CBTD.ApplicationCore.Models;
using CBTD.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBTDWeb.Pages.Products
{
	public class UpsertModel : PageModel
	{
		private readonly UnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

		[BindProperty]
		public Product objProduct { get; set; }

		public IEnumerable<SelectListItem> CategoryList { get; set; }
		public IEnumerable<SelectListItem> ManufacturerList { get; set; }

		public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}

		public IActionResult OnGet(int? id)
		{
			objProduct = new Product();
			CategoryList = _unitOfWork.Category.GetAll()
				.Select(c => new SelectListItem
				{
					Text = c.Name,
					Value = c.Id.ToString()
				}
				);
			ManufacturerList = _unitOfWork.Manufacturer.GetAll()
	.Select(m => new SelectListItem
	{
		Text = m.Name,
		Value = m.Id.ToString()
	}
	);
			if (id == null || id == 0) //Create mode
			{
				return Page();
			}
			
			if (id != 0 ) //Retrieve product from DB
			{
				objProduct = _unitOfWork.Product.GetById(id);
			}

			if(objProduct == null) //Maybe nothing returned
			{
				return NotFound();
			}

			return Page();
		}

		public IActionResult OnPost(int? id)
		{
			string webRootPath = _webHostEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;

			//if the product is new (create)

			if(objProduct.Id == 0)
			{
				//was there an image
				if (files.Count > 0)
				{
					//Create a unique identififer for image name
					string fileName = Guid.NewGuid().ToString();

					//Create variable to hold a path to images\products
					var uploads = Path.Combine(webRootPath, @"images\products\");

					//Get and preserve the extension type
					var extension = Path.GetExtension(files[0].FileName);

					//Create the full upload path

					var fullPath = uploads + fileName + extension;


					//Stream the binary write to the server
					
					using var fileStream = System.IO.File.Create(fullPath);
					files[0].CopyTo(fileStream);

					//associate the actual URL path and save to DB URLImage
					objProduct.ImageURL = @"\images\products\" + fileName + extension;
				}
				//add this new Product to the DB
				_unitOfWork.Product.Add(objProduct);
			}
			//The item exists, so we're updating it
			else
			{

			}
			objProduct = new Product();
			return Page();
		}
	}
}
