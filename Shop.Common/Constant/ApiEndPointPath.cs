namespace Shop.Common.Constant
{
    public static class ApiEndPointPath
    {
        private static string root = "api";

        private static string rootAdmin = $"{root}/admin";

        public static string AdminLogin = $"{rootAdmin}/login";

        public static string AdminSaveCategory = $"{rootAdmin}/save-category";

        public static string AdminUpdateCategory = $"{rootAdmin}/update-category";

        public static string AdminDeleteCategory = $"{rootAdmin}/delete-category";

        public static string AdminGetCategores = $"{rootAdmin}/get-categories";

        public static string AdminSaveProduct = $"{rootAdmin}/save-product";

        public static string AdminGetProducts = $"{rootAdmin}/get-products";

		public static string AdminDeleteProduct = $"{rootAdmin}/delete-product";
	}
}
