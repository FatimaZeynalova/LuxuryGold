// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.EntityFrameworkCore;


ProductManager productManager = new ProductManager(new EfProductDal());
	
foreach (var product in productManager.GetAllByCategoryId(1))
{
	Console.WriteLine(product.Name);
}


