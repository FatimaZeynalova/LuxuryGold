using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{

		private readonly IProductDal _productDal;
		ICategoryService _categoryService;

		public ProductManager(IProductDal productDal, ICategoryService categoryService)
		{
			_productDal = productDal;
			_categoryService = categoryService;
		}

		public IDataResult<List<Product>> GetAll()
		{
			if (DateTime.Now.Hour == 20)
			{
				return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
			}

			return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
		}

		
		[SecuredOperation("product.add,admin")]
		[ValidationAspect(typeof(ProductValidator))]
		public IResult Add(Product product)
		{
			//business codes
		

			IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
					CheckIfProductNameExists(product.Name), CheckIfCategoryLimitExceted(product.CategoryId));
			if (result != null)
			{
				return result;
			}
			_productDal.Add(product);
			return new SuccessResult(Messages.ProductAdded);
		}

		public IResult Delete(Product product)
		{
			_productDal.Delete(product);
			return new SuccessResult(Messages.ProductDeleted);
		}

		[ValidationAspect(typeof(ProductValidator))]
		public IResult Update(Product product)
		{


			_productDal.Update(product);
			return new SuccessResult(Messages.ProductUpdated);
		}

		public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
		}

		public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.Price >= min && p.Price <= max));
		}

		public IDataResult<List<ProductDetailDto>> GetProductDetails()
		{
			if (DateTime.Now.Hour == 16)
			{
				return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
		}

		public IDataResult<Product> GetById(int productId)
		{
			return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
		}







		private IResult CheckIfCategoryLimitExceted(int categoryId)
		{
			var result = _categoryService.GetAll();
			if (result.Data.Count>15)
			{
				return new ErrorResult(Messages.CategoryLimitExceded);

			}
			return new SuccessResult();
		}

		private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
		{
			//There can only be 10 products in a category.
			//Select count(*) from products where categoryId=1 = _productDal.GetAll(p => p.CategoryId == categoryId)
			var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
			if (result >= 10)
			{
				return new ErrorResult(Messages.ProductCountOfCategoryError);
			}

			return new SuccessResult();
		}
		private IResult CheckIfProductNameExists(string productName)
		{
			var result = _productDal.GetAll(p => p.Name == productName).Any();
			if (result)
			{
				return new ErrorResult(Messages.ProductNameAlreadyExists);
			}
			return new SuccessResult();

		}
	}
}