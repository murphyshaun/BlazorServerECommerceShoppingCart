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


	}
}