using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.EntityFrameworkCore;

//ProductTest();

//CategoryTest();


//static void ProductTest()
//{
//	ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal));

//	var result = productManager.GetProductDetails();

//	if (result.Success==true)
//	{
//		foreach (var product in result.Data)
//		{
//			Console.WriteLine(product.ProductName + "/" + product.CategoryName);
//		}
//	}
//	else
//	{
//		Console.WriteLine(result.Message);
//	}
//}

static void CategoryTest()
{
	CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
	var result = categoryManager.GetAll;
	foreach (var category in categoryManager.GetAll().Data)
	{
		Console.WriteLine(result);
	}
}