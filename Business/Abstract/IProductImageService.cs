using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IProductImageService
	{
		List<ProductImage> GetAll();
		void Add(ProductImage productImage);
		void Update(ProductImage productImage);
		void Delete(ProductImage productImage);
	}
}
