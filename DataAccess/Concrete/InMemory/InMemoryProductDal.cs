using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryProductDal : IProductDal
	{
		List<Product> _products;
		public InMemoryProductDal()
		{
			_products = new List<Product> 
			{ 
				new Product{ProductId=1,CategoryId=1,Name="Bardak",Price=15,StockQuantity=15, Weight=5},
				new Product{ProductId=2,CategoryId=1,Name="Kamera",Price=500,StockQuantity=3, Weight=2},
				new Product{ProductId=3,CategoryId=2,Name="Telefon",Price=1500,StockQuantity=2, Weight=1},
				new Product{ProductId=4,CategoryId=2,Name="Klavye",Price=150,StockQuantity=65, Weight=0.5m},
			};
		}
		public void Add(Product product)
		{
			_products.Add(product);
		}

		public void Delete(Product product)
		{
			Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);


			_products.Remove(productToDelete);

		}

		public Product Get()
		{
			throw new NotImplementedException();
		}

		public Product Get(Expression<Func<Product, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetAll()
		{
			return _products;

		}

		public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetAllByCategory(int categoryId)
		{
			return _products.Where(p => p.CategoryId == categoryId).ToList();
		}

		public void Update(Product product)
		{
			Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
			productToUpdate.Name = product.Name;
			productToUpdate.CategoryId = product.CategoryId;
			productToUpdate.Price = product.Price;
			productToUpdate.StockQuantity = product.StockQuantity;
			productToUpdate.Weight = product.Weight;
			productToUpdate.Description = product.Description;

		}
	}
}
