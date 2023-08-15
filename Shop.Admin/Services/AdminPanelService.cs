using Shop.DataModels.CustomModels;

namespace Shop.Admin.Services
{
	public class AdminPanelService : IAdminPanelService
	{
		private readonly HttpClient _httpClient;

		public AdminPanelService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ResponseModel> LoginAdmin(LoginModel loginModel)
		{
			var response = await _httpClient.PostAsJsonAsync("api/admin/AdminLogin", loginModel);

			return await response.Content.ReadFromJsonAsync<ResponseModel>();
		}
	}
}