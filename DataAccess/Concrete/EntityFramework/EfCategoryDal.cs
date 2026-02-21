using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	internal class EfCategoryDal : ICategoryDal
	{
		public void Add(Category entity)
		{
			using (LuxuryGoldContext context = new LuxuryGoldContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();
			}
		}

		public void Delete(Category entity)
		{
			using (LuxuryGoldContext context = new LuxuryGoldContext())
			{
				var deletedEntity = context.Entry(entity);
				deletedEntity.State = EntityState.Deleted ;
				context.SaveChanges();
			}
		}

		public Category Get()
		{
			throw new NotImplementedException();
		}

		public Category Get(Expression<Func<Category, bool>> filter = null)
		{
			using (LuxuryGoldContext context = new LuxuryGoldContext())
			{
				return context.Set<Category>().SingleOrDefault(filter);

			}
		}

		public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
		{
			using (LuxuryGoldContext context = new LuxuryGoldContext())
			{
				return filter == null
					? context.Set<Category>().ToList()
					: context.Set<Category>().Where(filter).ToList();
			}
		}
		public void Update(Category entity)
		{
			using (LuxuryGoldContext context = new LuxuryGoldContext())
			{
				var updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}
	}
}
