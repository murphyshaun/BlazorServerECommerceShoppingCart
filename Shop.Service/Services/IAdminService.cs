using Shop.DataModels.CustomModels;

namespace Shop.Logic.Services
{
	public interface IAdminService
	{
		Task<ResponseModel> LoginAdmin(LoginModel request);
	}
}