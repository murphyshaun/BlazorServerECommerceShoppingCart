using System.ComponentModel.DataAnnotations;

namespace Shop.DataModels.CustomModels
{
	public class ProductModel
	{
        public int Id { get; set; }

		[Required(ErrorMessage = "*Product name is required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "*Product price is required")]
		public int? Price { get; set; }

        [Required(ErrorMessage = "*Product stock is required")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "*Product Category is required")]
        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; } = string.Empty;

        public string? ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "*Upload product photo")]
        public string FileName { get; set; }

        public byte[] FileContent { get; set; }

        public bool CartFlag { get; set; }
    }
}