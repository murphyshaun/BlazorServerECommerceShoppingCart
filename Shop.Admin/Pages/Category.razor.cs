using Microsoft.AspNetCore.Components;
using Shop.Admin.Services;
using Shop.Common.Constant;
using Shop.DataModels.CustomModels;

namespace Shop.Admin.Pages
{
	public partial class Category
	{
		[Inject]
		public IAdminPanelService adminPanelService { get; set; }

		[CascadingParameter]
		public EventCallback notify { get; set; }

		public CategoryModel categoryModel { get; set; }
		public CategoryModel categoryToDelete { get; set; }
		public CategoryModel categoryToUpdate { get; set; }
		public List<CategoryModel> categoryList { get; set; }

		public bool isSuccessPopup { get; set; }
		public bool isShowDeletePopup { get; set; }
		public bool isShowEditPopup { get; set; }
		public string message { get; set; }

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
				await notify.InvokeAsync();
		}

		protected override async Task OnInitializedAsync()
		{
			categoryModel = new CategoryModel();
			await GetCategories();
		}

		private async Task SaveCategory()
		{
			await adminPanelService.SaveCategory(categoryModel);

			message = MessageManager.CATEGORY_ADD_SECCESS;

			ToggleSuccessPopup();

			await GetCategories();

			ClearForm();
		}

		private async Task GetCategories()
		{
			categoryList = await adminPanelService.GetCategories();
		}

		private void ClearForm()
		{
			categoryModel = new CategoryModel();
		}

		private void EditCategoryButtonOnClick(CategoryModel category)
		{
			categoryToUpdate = category;
			ToggleEditPopup();
		}

		private void DeleteCategoryButtonOnClick(CategoryModel category)
		{
			categoryToDelete = category;
			ToggleDeletePopup();
		}

		private async Task HandleUpdateCategory()
		{
			var flag = await adminPanelService.UpdateCategory(categoryToUpdate);

			ToggleEditPopup();

			message = flag ? MessageManager.CATEGORY_UPDATE_SECCESS : MessageManager.CATEGORY_UPDATE_FAIL;

			ToggleSuccessPopup();
			categoryToUpdate = new CategoryModel();
			await GetCategories();
		}

		private async Task HandleDeleteCategory()
		{
			var flag = await adminPanelService.DeleteCategory(categoryToDelete);
			ToggleDeletePopup();

			message = flag ? MessageManager.CATEGORY_DELETE_SECCESS : MessageManager.CATEGORY_DELETE_FAIL;

			ToggleSuccessPopup();
			categoryToDelete = new CategoryModel();
			await GetCategories();
		}

		private void ToggleSuccessPopup() => isSuccessPopup = !isSuccessPopup;

		private void ToggleDeletePopup() => isShowDeletePopup = !isShowDeletePopup;

		private void ToggleEditPopup() => isShowEditPopup = !isShowEditPopup;
	}
}