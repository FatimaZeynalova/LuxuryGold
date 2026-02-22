using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfProductDal : EFEntityRepositoryBase<Product, LuxuryGoldContext>, IProductDal
	{
		public List<ProductDetailDto> GetProductDetails()
		{
			using (LuxuryGoldContext context= new LuxuryGoldContext())
			{
				var result = from p in context.Products
							 join c in context.Categories
							 on p.CategoryId equals c.CategoryId
							 select new ProductDetailDto
							 {
								 ProductId = p.ProductId,
								 ProductName = p.Name,
								 CategoryName = c.Name,
								 StockQuantity = p.StockQuantity
							 };
				return result.ToList();
			}

		}
	}
}
