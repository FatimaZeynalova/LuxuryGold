using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}
		public void Add(Category category)
		{
			throw new NotImplementedException();
		}

		public void Delete(Category category)
		{
			throw new NotImplementedException();
		}

		public List<Category> GetAll()
		{
			return _categoryDal.GetAll();
		}

		public void Update(Category category)
		{
			throw new NotImplementedException();
		}

		Category ICategoryService.GetById(int categoryId)
		{
			return _categoryDal.Get(c => c.CategoryId == categoryId);
		}
	}
}
