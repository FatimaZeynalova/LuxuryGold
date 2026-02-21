using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public List<Product> GetAll()
		{
			return _productDal.GetAll();
		}

		public void Add(Product product)
		{
			_productDal.Add(product);
		}

		public void Delete(Product product)
		{
			_productDal.Delete(product);
		}

		public void Update(Product product)
		{
			_productDal.Update(product);
		}

		public List<Product> GetAllByCategoryId(int categoryId)
		{
			return _productDal.GetAll(p => p.CategoryId == categoryId);
		}

		public List<Product> GetAllByUnitPrice(decimal min, decimal max)
		{
			return _productDal.GetAll(p => p.Price >= min && p.Price <= max);
		}
	}
}