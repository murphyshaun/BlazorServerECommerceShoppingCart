﻿using Shop.DataModels.CustomModels;

namespace Shop.Admin.Services
{
	public interface IAdminPanelService
	{
		Task<ResponseModel> LoginAdmin(LoginModel loginModel);

		Task<CategoryModel> SaveCategory(CategoryModel categoryModel);
		
		Task<List<CategoryModel>> GetCategories();

		Task<bool> UpdateCategory(CategoryModel categoryModel);

		Task<bool> DeleteCategory(CategoryModel categoryModel);
	}
}
