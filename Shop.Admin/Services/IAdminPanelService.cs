using Shop.DataModels.CustomModels;

namespace Shop.Admin.Services
{
	public interface IAdminPanelService
	{
		Task<ResponseModel> LoginAdmin(LoginModel loginModel);
	}
}
