using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IProductService
	{
		List<Product> GetAll();
		//Product GetById(int id);
		void Add(Product product);
		void Update(Product product);
		void Delete(Product product);
		List<Product> GetAllByCategoryId(int categoryId);
		List<Product> GetAllByUnitPrice(decimal min, decimal max);
	}
}
