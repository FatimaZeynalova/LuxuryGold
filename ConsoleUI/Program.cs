using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.EntityFrameworkCore;

//ProductTest();

CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
foreach (var category in categoryManager.GetAll())
{
	Console.WriteLine(category.Name);
}



static void ProductTest()
{
	ProductManager productManager = new ProductManager(new EfProductDal());

	foreach (var product in productManager.GetAllByCategoryId(1))
	{
		Console.WriteLine(product.Name);
	}
}

