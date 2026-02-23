using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public IResult Add(Category category)
		{
			_categoryDal.Add(category);
			return new SuccessResult("Category added successfully.");
		}

		public IResult Delete(Category category)
		{
			_categoryDal.Delete(category);
			return new SuccessResult("Category deleted successfully.");
		}

		public IDataResult<List<Category>> GetAll()
		{
			if (DateTime.Now.Hour == 23)
			{
				return new ErrorDataResult<List<Category>>("System is under maintenance.");
			}
			return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());

		}
		public IResult Update(Category category)
		{
			_categoryDal.Update(category);
			return new SuccessResult("Category updated successfully.");
		}

		IDataResult<Category> ICategoryService.GetById(int categoryId)
		{
			return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
		}
	}
}
