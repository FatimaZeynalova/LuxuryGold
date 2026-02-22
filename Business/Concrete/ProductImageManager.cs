using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ProductImageManager : IProductImageService
	{

		IProductImageDal _productImageDal;
		public ProductImageManager(IProductImageDal productImageDal)
		{
			_productImageDal= productImageDal;
		}

		public void Add(ProductImage productImage)
		{
			throw new NotImplementedException();
		}

		public void Delete(ProductImage productImage)
		{
			throw new NotImplementedException();
		}

		public List<ProductImage> GetAll()
		{
			return _productImageDal.GetAll();
		}

		public void Update(ProductImage productImage)
		{
			throw new NotImplementedException();
		}
	}
}
