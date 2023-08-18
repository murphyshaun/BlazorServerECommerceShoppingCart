using Microsoft.AspNetCore.Mvc;
using Shop.DataModels.CustomModels;
using Shop.Logic.Services;

namespace Shop.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IAdminService _adminService;
		private readonly IWebHostEnvironment _env;

		public AdminController(IAdminService adminService, IWebHostEnvironment env)
		{
			_adminService = adminService;
			_env = env;
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAdmin(LoginModel request)
		{
			var data = await _adminService.LoginAdmin(request);

			return Ok(data);
		}

		[HttpPost("save-category")]
		public async Task<IActionResult> SaveCategory(CategoryModel request)
		{
			var data = await _adminService.SaveCategory(request);

			return Ok(data);
		}

		[HttpGet("get-categories")]
		public async Task<IActionResult> GetCategories()
		{
			var categories = await _adminService.GetCategories();
			return Ok(categories);
		}

		[HttpPost("update-category")]
		public async Task<IActionResult> UpdateCategory(CategoryModel request)
		{
			var response = await _adminService.UpdateCategory(request);
			return Ok(response);
		}

		[HttpPost("delete-category")]
		public async Task<IActionResult> DeleteCategory(CategoryModel request)
		{
			var response = await _adminService.DeleteCategory(request);
			return Ok(response);
		}

		[HttpGet("get-products")]
		public async Task<IActionResult> GetProducts()
		{
			var products = await _adminService.GetProducts();
			return Ok(products);
		}

		[HttpDelete("delete-product/{id:int}")]
		public async Task<IActionResult> DeleteProduct([FromRoute] int id)
		{
			var response = await _adminService.DeleteProduct(id);
			return Ok(response);
		}

		[HttpPost("save-product")]
		public async Task<IActionResult> SaveProduct(ProductModel request)
		{
			var nameImage = Guid.NewGuid();

			request.ImageUrl = @$"Images/{nameImage}.png";
			var path = $"{_env.ContentRootPath}\\Images\\{nameImage}.png";
			var fs = System.IO.File.Create(path);
			fs.Write(request.FileContent, 0, request.FileContent.Length);
			fs.Close();

			//string uploadsFolder = Path.Combine(_env.WebRootPath, "Images");

;			var data = await _adminService.SaveProduct(request);

			return Ok(data);
		}
	}
}