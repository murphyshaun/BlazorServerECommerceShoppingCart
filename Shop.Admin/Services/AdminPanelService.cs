using Shop.Common.Constant;
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

		/// <summary>
		/// Logins the admin.
		/// </summary>
		/// <param name="loginModel">The login model.</param>
		/// <returns></returns>
		public async Task<ResponseModel> LoginAdmin(LoginModel loginModel)
		{
			var response = await _httpClient.PostAsJsonAsync(ApiEndPointPath.AdminLogin, loginModel);

			return await response.Content.ReadFromJsonAsync<ResponseModel>();
		}

		/// <summary>
		/// Saves the category.
		/// </summary>
		/// <param name="categoryModel">The category model.</param>
		/// <returns></returns>
		public async Task<CategoryModel> SaveCategory(CategoryModel categoryModel)
		{
			var response = await _httpClient.PostAsJsonAsync(ApiEndPointPath.AdminSaveCategory, categoryModel);

			return await response.Content.ReadFromJsonAsync<CategoryModel>();
		}


		public async Task<List<CategoryModel>> GetCategories()
		{
			var response = await _httpClient.GetAsync(ApiEndPointPath.AdminGetCategores);

			return await response.Content.ReadFromJsonAsync<List<CategoryModel>>();
		}

		/// <summary>
		/// Updates the category.
		/// </summary>
		/// <param name="categoryModel">The category model.</param>
		/// <returns></returns>
		public async Task<bool> UpdateCategory(CategoryModel categoryModel)
		{
			var response = await _httpClient.PostAsJsonAsync(ApiEndPointPath.AdminUpdateCategory, categoryModel);

			return await response.Content.ReadFromJsonAsync<bool>();
		}

		/// <summary>
		/// Deletes the category.
		/// </summary>
		/// <param name="categoryModel">The category model.</param>
		/// <returns></returns>
		public async Task<bool> DeleteCategory(CategoryModel categoryModel)
		{
			var response = await _httpClient.PostAsJsonAsync(ApiEndPointPath.AdminDeleteCategory, categoryModel);

			return await response.Content.ReadFromJsonAsync<bool>();
		}

		/// <summary>
		/// Gets the products.
		/// </summary>
		/// <returns></returns>
		public async Task<List<ProductModel>> GetProducts()
		{
			return await _httpClient.GetFromJsonAsync<List<ProductModel>>(ApiEndPointPath.AdminGetProducts);
		}

		/// <summary>
		/// Deletes the product.
		/// </summary>
		/// <param name="productId">The product identifier.</param>
		/// <returns></returns>
		public async Task<bool> DeleteProduct(int productId)
		{
			var response = await _httpClient.DeleteAsync($"{ApiEndPointPath.AdminDeleteProduct}/{productId}");

			return await response.Content.ReadFromJsonAsync<bool>();
		}

		/// <summary>
		/// Saves the product.
		/// </summary>
		/// <param name="productModel">The product model.</param>
		/// <returns></returns>
		public async Task<ProductModel> SaveProduct(ProductModel productModel)
		{
			var response = await _httpClient.PostAsJsonAsync(ApiEndPointPath.AdminSaveProduct, productModel);

			return await response.Content.ReadFromJsonAsync<ProductModel>();
		}
	}
}