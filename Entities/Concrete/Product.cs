using Core.Entities;

namespace Entities.Concrete

{
	public class Product: IEntity
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public decimal Weight { get; set; }
		public int StockQuantity { get; set; }
		public int CategoryId { get; set; }
		public Category? Category { get; set; }
		public bool IsFeatured { get; set; } = false;
		public bool IsActive { get; set; } = true;
		public ICollection<ProductImage>? Images { get; set; }
	}
}
