using Shop.DataModels.CustomModels;

namespace Shop.Logic.Services
{
	public interface IAdminService
	{
		Task<ResponseModel> LoginAdmin(LoginModel request);
		
		Task<CategoryModel> SaveCategory(CategoryModel request);
		Task<bool> UpdateCategory(CategoryModel request);
		Task<bool> DeleteCategory(CategoryModel request);

		Task<List<CategoryModel>> GetCategories();
	}
}