using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public IDataResult<List<Product>> GetAll()
		{
			if (DateTime.Now.Hour == 23)
			{
				return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
			}

			return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed) ;
		}

		public IResult Add(Product product)
		{
			if (product.Name.Length < 2)
			{
				return new ErrorResult(Messages.ProductNameInvalid);
			}

			_productDal.Add(product);
			return new SuccessResult(Messages.ProductAdded);
		}

		public IResult Delete(Product product)
		{
			_productDal.Delete(product);
			return new SuccessResult(Messages.ProductDeleted);
		}

		public IResult Update(Product product)
		{
			_productDal.Update(product);
			return new SuccessResult(Messages.ProductUpdated);
		}

		public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
		{
			return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryId == categoryId));
		}

		public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.Price >= min && p.Price <= max));
		}

		public IDataResult<List<ProductDetailDto>> GetProductDetails()
		{
			if (DateTime.Now.Hour == 16)
			{
				return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails());
		}

		public IDataResult<Product> GetById(int productId)
		{
			return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
		}
	}
}