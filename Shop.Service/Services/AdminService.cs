using Microsoft.EntityFrameworkCore;
using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;

namespace Shop.Logic.Services
{
	public class AdminService : IAdminService
	{
		private readonly ShoppingCardDbContext _dbContext;

		public AdminService(ShoppingCardDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<ResponseModel> LoginAdmin(LoginModel request)
		{
			var response = new ResponseModel
			{
				Status = false,
				Message = "Incorrect Id / Password"
			};

			try
			{
				var userData = await _dbContext.AdminInfos.SingleOrDefaultAsync(c => c.Password == request.Password && c.Email == request.Email);

				if (userData is not null)
				{
					response.Status = true;
					response.Message = $"{userData.Id} | {userData.Name} | {userData.Email}";
				}
			}
			catch (Exception)
			{
				response.Message = "An Error has occured. Please try again!";
			}

			return response;
		}
	}
}