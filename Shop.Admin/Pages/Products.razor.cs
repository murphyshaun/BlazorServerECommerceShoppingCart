using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shop.Admin.Services;
using Shop.Common.Constant;
using Shop.Common.Extension;
using Shop.DataModels.CustomModels;

namespace Shop.Admin.Pages
{
	public partial class Products
	{
		[Inject]
		public IAdminPanelService adminPanelService { get; set; }

		[CascadingParameter]
		public EventCallback notify { get; set; }

		public List<CategoryModel> categoryList { get; set; }
		public ProductModel productModel { get; set; }
		public List<ProductModel> productList { get; set; }
		public int categoryId { get; set; }
		private IReadOnlyList<IBrowserFile> selectedFiles;
		private List<string> imageUrls = new List<string>();
		public ProductModel propductToUpdate { get; set; }
		public ProductModel propductToDelete { get; set; }
		public bool isSuccessPopup { get; set; }
		public bool isShowDeletePopup { get; set; }
		public bool isShowEditPopup { get; set; }
		public string message { get; set; }

		protected override async Task OnInitializedAsync()
		{
			productModel = new ProductModel();
			await GetCategories();
			await GetProducts();
		}

		private async Task GetCategories()
		{
			categoryList = await adminPanelService.GetCategories();
		}

		private async Task GetProducts()
		{
			productList = await adminPanelService.GetProducts();
		}

		private async Task SaveProduct()
		{
			Stream stream = selectedFiles.FirstOrDefault().OpenReadStream();
			MemoryStream ms = new MemoryStream();
			await stream.CopyToAsync(ms);
			stream.Close();

			productModel.CategoryId = categoryId;
			productModel.FileName = selectedFiles.FirstOrDefault().Name;
			productModel.FileContent = ms.ToArray();
			ms.Close();

			await adminPanelService.SaveProduct(productModel);

			await GetProducts();

			ClearForm();
		}

		private void ClearForm()
		{
			productModel = new ProductModel();
			imageUrls.Clear();
		}

		private async Task OnInputFileChage(InputFileChangeEventArgs e)
		{
			selectedFiles = e.GetMultipleFiles();
			productModel.FileName = string.Empty;

			foreach (var imageFile in selectedFiles)
			{
				var resizedImage = await imageFile.RequestImageFileAsync("image/jpg", 100, 100);
				var buffer = new byte[resizedImage.Size];
				await resizedImage.OpenReadStream().ReadAsync(buffer);
				var imageData = $"data:image/jpg;base64,{Convert.ToBase64String(buffer)}";
				imageUrls.Add(imageData);
				productModel.FileName = imageFile.Name;
			}

			message = $"{selectedFiles.Count} file(s) selected";
			this.StateHasChanged();
		}

		private void CategoryClicked(ChangeEventArgs categoryEvent)
		{
			var value = categoryEvent.Value.ToString();
			if (!string.IsNullOrEmpty(value))
			{
				categoryId = value.StringToInt();
				productModel.CategoryId = categoryId;
				this.StateHasChanged();
			}
		}

		private void EditProductButtonOnClick(ProductModel product)
		{
			propductToUpdate = product;
			ToggleEditPopup();
		}

		private void DeleteProductButtonOnClick(ProductModel product)
		{
			propductToDelete = product;
			ToggleDeletePopup();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
				await notify.InvokeAsync();
		}

		private async Task HandleDeleteProduct()
		{
			var flag = await adminPanelService.DeleteProduct(propductToDelete.Id);
			ToggleDeletePopup();

			message = flag ? MessageManager.PRODUCT_DELETE_SECCESS : MessageManager.PRODUCT_DELETE_FAIL;

			ToggleSuccessPopup();
			propductToDelete = new ProductModel();
			await GetProducts();
		}

		private void ToggleSuccessPopup() => isSuccessPopup = !isSuccessPopup;

		private void ToggleDeletePopup() => isShowDeletePopup = !isShowDeletePopup;

		private void ToggleEditPopup() => isShowEditPopup = !isShowEditPopup;
	}
}