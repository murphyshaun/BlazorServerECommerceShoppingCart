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

		[HttpPost("AdminLogin")]
		public async Task<IActionResult> LoginAdmin(LoginModel request)
		{
			var data = await _adminService.LoginAdmin(request);

			return Ok(data);
		}
	}
}